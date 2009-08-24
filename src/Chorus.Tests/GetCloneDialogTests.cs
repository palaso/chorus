﻿using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Chorus.UI.Clone;
using Chorus.Utilities;
using Chorus.Utilities.UsbDrive;
using Chorus.VcsDrivers.Mercurial;
using NUnit.Framework;

namespace LibChorus.Tests
{
	[TestFixture]
	public class GetCLoneDialogTests
	{
		[Test, Ignore("Run by hand only")]
		public void LaunchDialog_LiveTest()
		{
			using (var f = new TempFolder("clonetest"))
			{
				using (var dlg = new GetCloneDialog(f.Path))
				{
					if(DialogResult.OK != dlg.ShowDialog())
						return;
					//var repo = new HgRepository(dlg.PathToNewProject, new NullProgress());
				}
			}
		}

		[Test, Ignore("Run by hand only")]
		public void LaunchDialog_SimulatedUsb_ProjectAlreadyExists()
		{
			using (var targetComputer = new TempFolder("clonetest-targetComputer"))
			using (var usb = new TempFolder("clonetest-Usb"))
			{
				Directory.CreateDirectory(usb.Combine("repo1"));
				HgRepository.CreateRepositoryInExistingDir(usb.Combine("repo1"), new NullProgress());

				//ok, the point here is that we already haved something called "repo1"
				Directory.CreateDirectory(targetComputer.Combine("repo1"));

				using (var dlg = new GetCloneDialog(targetComputer.Path))
				{
					var drives = new List<IUsbDriveInfo>();
					drives.Add(new UsbDriveInfoForTests(usb.Path));

					//don't look at the actual drives, look at our simulations
					dlg.Model.DriveInfoRetriever = new RetrieveUsbDriveInfoForTests(drives);

					if (DialogResult.OK != dlg.ShowDialog())
						return;
				}
			}
		}


	}
}