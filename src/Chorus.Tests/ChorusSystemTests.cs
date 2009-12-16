﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Chorus.notes;
using Chorus.Utilities;
using NUnit.Framework;

namespace Chorus.Tests
{
	[TestFixture]
	public class ChorusSystemTests
	{
		private TempFolder _folder;
		private TempFile _targetFile1;
		private TempFile _existingNotesFile;
		private ChorusSystem _system;
		private IProgress _progress = new NullProgress();

		[SetUp]
		public void Setup()
		{
			_folder = new TempFolder("ChorusSystemTests");
			_targetFile1 = new TempFile(_folder,  "one.txt", "just a pretend file");
			_existingNotesFile = new TempFile(_folder, "one.txt" + AnnotationRepository.FileExtension,
						@"<notes version='0'>
					<annotation ref='somwhere://foo?id=x' class='mergeConflict'>
						<message guid='123' author='merger' status='open' date='2009-07-18T23:53:04Z'>
							some description of the conflict
						</message>
					</annotation>
				</notes>");

			_system = new ChorusSystem(_folder.Path);
		}

		[TearDown]
		public void TearDown()
		{
			_system.Dispose();
			_targetFile1.Dispose();
			_existingNotesFile.Dispose();
			_folder.Dispose();
		}


		/// <summary>
		/// This is largely a test of the DI Container setup, since problems there aren't
		/// found at compile time
		/// </summary>
		[Test]
		public void CanShowNotesBrowserPage()
		{
			var page = _system.WinForms.CreateNotesBrowser();
			ShowWindowWithControlThenClose(page);
		}

		/// <summary>
		/// This is largely a test of the DI Container setup, since problems there aren't
		/// found at compile time
		/// </summary>
		[Test]
		public void CanShowNotesBar()
		{
			var view = _system.WinForms.CreateNotesBar(_targetFile1.Path, new NotesToRecordMapping(), _progress);
			ShowWindowWithControlThenClose(view);
		}


		private static void ShowWindowWithControlThenClose(Control control)
		{
			control.Dock = DockStyle.Fill;
			var form = new Form();
			form.Size = new Size(700, 600);
			form.Controls.Add(control);
			Application.Idle += new EventHandler(Application_Idle);
			Application.EnableVisualStyles();
			Application.Run(form);
		}


		static void Application_Idle(object sender, EventArgs e)
		{
			Thread.Sleep(100);
			Application.Exit();
		}
		/// <summary>
		/// This tests hat we're using the same repositories for all instances of Notes UI components
		/// </summary>
		[Test]
		public void GetNotesBarAndBrowser_MakeNewAnnotationWithBar_BrowserSeesIt()
		{
				NotesToRecordMapping mapping =  NotesToRecordMapping.SimpleForTest();
				var bar = _system.WinForms.CreateNotesBar(_targetFile1.Path, mapping, _progress);
				var browser = _system.WinForms.CreateNotesBrowser();
				Assert.AreEqual(0, browser._notesInProjectModel.GetMessages().Count());

				bar.SetTargetObject(this);
				var a = bar._model.CreateAnnotation();
				a.AddMessage("test", "open", "hello");
				Assert.AreEqual(1, browser._notesInProjectModel.GetMessages().Count());
		}

	}
}