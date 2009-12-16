using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Chorus.FileTypeHanders.xml;
using Chorus.merge;
using Chorus.merge.xml.generic;
using Chorus.Utilities;
using Chorus.VcsDrivers.Mercurial;

namespace Chorus.FileTypeHanders
{
	/// <summary>
	/// The Chorus Notes file is a "stand-off markup" file of annotations.
	/// It facilitate workflow of a team working on the target document, such as a dictionary.
	/// The file name is the target file + ".ChorusNotes".
	/// ChorusNotes-aware applications will make additions to let the team discuss issues and
	/// marke the status of things.  In addition, the chorus merger adds annotations when
	/// it encounters a conflict, so that the team can later review what was done by the merger and make changes.
	/// </summary>
	public class ChorusNotesFileHandler : IChorusFileTypeHandler
	{
		public bool CanDiffFile(string pathToFile)
		{
			return CanMergeFile(pathToFile);
		}

		public bool CanMergeFile(string pathToFile)
		{
			return (System.IO.Path.GetExtension(pathToFile) == ".ChorusNotes");
		}

		public bool CanPresentFile(string pathToFile)
		{
			return CanDiffFile(pathToFile);
		}


		public bool CanValidateFile(string pathToFile)
		{
			return false;
		}
		public string ValidateFile(string pathToFile, IProgress progress)
		{
			throw new NotImplementedException();
		}

		public void Do3WayMerge(MergeOrder order)
		{
			XmlMerger merger  = new XmlMerger(order.MergeSituation);
			SetupElementStrategies(merger);
			var r = merger.MergeFiles(order.pathToOurs, order.pathToTheirs, order.pathToCommonAncestor);
			File.WriteAllText(order.pathToOurs, r.MergedNode.OuterXml);
		}
		private void SetupElementStrategies(XmlMerger merger)
		{
			merger.MergeStrategies.SetStrategy("annotation", ElementStrategy.CreateForKeyedElement("guid", false));
			ElementStrategy messageStrategy = ElementStrategy.CreateForKeyedElement("guid", false);
			messageStrategy.IsImmutable = true;
			merger.MergeStrategies.SetStrategy("message", messageStrategy);
		}

		public IEnumerable<IChangeReport> Find2WayDifferences(FileInRevision parent, FileInRevision child, HgRepository repository)
		{
			var listener = new ChangeAndConflictAccumulator();
						//pull the files out of the repository so we can read them
			using (var childFile = child.CreateTempFile(repository))
			using (var parentFile = parent.CreateTempFile(repository))
			{

				var differ = ChorusNotesDiffer.CreateFromFiles(parentFile.Path, childFile.Path, listener);
				differ.ReportDifferencesToListener();
				return listener.Changes;
			}
		}

		public IChangePresenter GetChangePresenter(IChangeReport report, HgRepository repository)
		{
			if ((report as IXmlChangeReport) != null)
			{
				return new ConflictPresenter(report as IXmlChangeReport, repository);
			}
			else
			{
				return new DefaultChangePresenter(report, repository);
			}
		}



		public IEnumerable<IChangeReport> DescribeInitialContents(FileInRevision fileInRevision, TempFile file)
		{
			var dom = new XmlDocument();
			dom.Load(file.Path);


			foreach (XmlNode e in dom.SafeSelectNodes("notes/annotation"))
			{
				yield return new XmlAdditionChangeReport(fileInRevision, e);
			}
		}

		public IEnumerable<string> GetExtensionsOfKnownTextFileTypes()
		{
			yield return ".ChorusNotes";
		}
	}
}