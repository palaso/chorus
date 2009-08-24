﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Chorus.Utilities;
using Chorus.Utilities.UsbDrive;
using Chorus.VcsDrivers.Mercurial;

namespace Chorus.clone
{
	/// <summary>
	/// Use this class to make an initial clone from a USB drive or Internet repository.
	/// Note, most clients can instead use the GetCloneDialog in Chorus.exe.
	/// </summary>
	public class Cloner
	{
		public event EventHandler LoadList;

		public Cloner()
		{
			DriveInfoRetriever = new RetrieveUsbDriveInfo();
		}

		/// <summary>
		/// Use this to insert an artificial drive info system for unit tests
		/// </summary>
		public IRetrieveUsbDriveInfo DriveInfoRetriever { get; set; }

		public bool GetHaveOneOrMoreUsbDrives()
		{
			return DriveInfoRetriever.GetDrives().Count > 0;
		}

		public IEnumerable<string> GetDirectoriesWithMecurialRepos()
		{
			foreach (var drive in DriveInfoRetriever.GetDrives())
			{
				foreach (var dir in Directory.GetDirectories(drive.RootDirectory.FullName))
				{
					if (Directory.Exists(Path.Combine(dir, ".hg")))
					{
						yield return dir;
					}
					else //we'll look just at the next level down
					{
						foreach (var subdir in Directory.GetDirectories(dir))
						{
							if (Directory.Exists(Path.Combine(subdir, ".hg")))
							{
								yield return subdir;
							}
						}
					}
				}
			}

		}

		public string MakeClone(string sourcePath, string parentDirectoryToPutCloneIn, IProgress progress)
		{
			var target = Path.Combine(parentDirectoryToPutCloneIn, Path.GetFileName(sourcePath));
			if(Directory.Exists(target))
				throw new ApplicationException("Cannot clone onto an existing directory ("+target+")");

			var repo = new HgRepository(sourcePath, progress);

			repo.Clone(target);
			return target;
		}

	}
}