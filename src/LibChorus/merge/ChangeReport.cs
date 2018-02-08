// Copyright (c) 2018 SIL International
// This software is licensed under the MIT License (http://opensource.org/licenses/MIT)
using System;
using Chorus.VcsDrivers.Mercurial;
using Palaso.Providers;

namespace Chorus.merge
{
	public abstract class ChangeReport : IChangeReport
	{
		public FileInRevision ChildFileInRevision { get; private set; }
		public FileInRevision ParentFileInRevision { get; private set; }
		protected Guid _guid = GuidProvider.Current.NewGuid();

		//        public override bool Equals(object obj)
		//        {
		//            if(GetType() != obj.GetType())
		//                return false;
		//            IChangeReport other = obj as IChangeReport;
		//            return PathToFile == other.PathToFile
		//                && ActionLabel == other.ActionLabel;  //don't compare guids!
		//        }
		//        public override int GetHashCode()
		//        {
		//            return PathToFile.GetHashCode() + ActionLabel.GetHashCode();
		//        }


		//        protected ChangeReport(FileInRevision fileInRevision)
		//        {
		//            ChildFileInRevision = fileInRevision;
		//        }
		protected ChangeReport(FileInRevision parent, FileInRevision child)
		{
			ChildFileInRevision = child;
			ParentFileInRevision = parent;
		}
		public Guid Guid
		{
			get { return _guid; }
		}

		public virtual string ActionLabel
		{
			get { return GetType().ToString(); }
		}

		public string PathToFile
		{
			get
			{
				if(null== ChildFileInRevision)
					return null;
				else
					return ChildFileInRevision.FullPath;
			}
		}

		public virtual string UrlOfItem
		{
			get { return string.Empty; }
		}

		public override string ToString()
		{
			return GetFullHumanReadableDescription();
		}

		public virtual string GetFullHumanReadableDescription()
		{
			return ActionLabel;
		}

	}

}
