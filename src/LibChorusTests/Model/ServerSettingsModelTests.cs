using System;
using System.IO;
using NUnit.Framework;
using SIL.Progress;
using SIL.TestUtilities;
using Chorus.Model;
using Chorus.VcsDrivers;
using Chorus.VcsDrivers.Mercurial;
using Newtonsoft.Json;

namespace LibChorus.Tests.Model
{
	[TestFixture]
	public class ServerSettingsModelTests
	{
		[Test]
		public void InitFromUri_FullTypicalLangDepot_AccountNameCorrect()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://joe:pass@hg-public.languageforge.org/tpi");
			Assert.AreEqual("joe", m.Username);
		}

		[Test]
		public void InitFromUri_CredentialsOriginallySetFromModelWithSpecialCharacters_AbleToRoundTripCredentialsBackFromURIOK()
		{
			var model = new ServerSettingsModel();
			const string accountName = "joe@user.com";
			const string password = "pass@with%specials&";
			const string projectId = "projectId";
			model.Username = accountName;
			model.Password = password;
			model.ProjectId = projectId;
			var urlWithEncodedChars = model.URL;

			var newModel = new ServerSettingsModel();
			newModel.InitFromUri(urlWithEncodedChars);
			// TODO (Hasso) 2020.10: how to test?
			//Assert.AreEqual(accountName, newModel.Username);
			//Assert.AreEqual(password, newModel.Password);
			Assert.AreEqual(projectId, newModel.ProjectId);
		}

		[Test]
		public void InitFromUri_FullTypicalLangDepot_PasswordCorrect()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://joe:pass@hg-public.languageforge.org/tpi");
			Assert.AreEqual("pass", m.Password);
		}

		[Test]
		public void InitFromUri_FullTypicalLangDepot_ProjectIdCorrect()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://joe:pass@hg-public.languageforge.org/tpi");
			Assert.AreEqual("tpi", m.ProjectId);
		}

		[Test]
		public void InitFromUri_FullTypicalLangDepot_DomainAndBandwidthCorrect()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://joe:pass@hg-public.languageforge.org/tpi");
			Assert.AreEqual("hg-public.languageforge.org", m.Host);
		}

		[Test]
		public void InitFromUri_ResumableLangDepot_DomainAndBandwidthCorrect()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://resumable.languageforge.org/tpi");
			Assert.AreEqual("resumable.languageforge.org", m.Host);
			Assert.AreEqual(new ServerSettingsModel.BandwidthItem(ServerSettingsModel.BandwidthEnum.Low), m.Bandwidth);
		}

		[Test]
		public void InitFromUri_FullTypicalLangDepot_CustomUrlFalse()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://joe:pass@hg-public.languageforge.org/tpi");
			Assert.IsFalse(m.IsCustomUrl);
		}

		[Test]
		public void InitFromUri_HasFolderDesignator_IdIsCorrect()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://joe:pass@hg-public.languageforge.org/tpi?localFolder=foo");
			Assert.AreEqual("tpi", m.ProjectId);
		}

		[Test]
		public void InitFromUri_UnknownHttpGiven_CustomUrlIsTrue()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("https://somewhereelse.net/xyz");
			Assert.IsTrue(m.IsCustomUrl);
		}

		[Test]
		public void InitFromUri_LANPathGiven_CustomUrlIsTrue()
		{
			var m = new ServerSettingsModel();
			m.InitFromUri("\\mybox\tpi");
			Assert.IsTrue(m.IsCustomUrl);
		}

		[Test]
		public void InitFromUri_NoUsernameOrPass_UsesSettings()
		{
			var m = new ServerSettingsModel
			{
				Username = "john",
				Password = "settings"
			};
			m.InitFromUri("https://hg.languageforge.org/tpi");
			Assert.AreEqual("john", m.Username);
			Assert.AreEqual("settings", m.Password);
			Assert.AreEqual("tpi", m.ProjectId);
		}

		[Test]
		public void InitFromUri_UsernameAndPass_OverwritesSettings()
		{
			var m = new ServerSettingsModel
			{
				Username = "from",
				Password = "settings"
			};
			m.InitFromUri("https://jan:pass@hg-public.languageforge.org/tps");
			Assert.AreEqual("jan", m.Username);
			Assert.AreEqual("pass", m.Password);
			Assert.AreEqual("tps", m.ProjectId);
		}

		[Test]
		public void PopulateAvailableProjects()
		{
			const string id1 = "nko";
			const string id2 = "atinlay-dictionary";
			const string id3 = "wra-ramo-dict";
			const string json = @"[
			{
				 ""identifier"":""" + id1 + @""",
				 ""name"":""Nkonya 2011"",
				 ""repository"":""http:\/\/public.languageforge.org"",
				 ""role"":""unknown""
			},
			{
				 ""identifier"":""" + id2 + @""",
				 ""name"":""Atinlay Dictionary"",
				 ""repository"":""http:\/\/public.languageforge.org"",
				 ""role"":""manager""
			},
			{
				 ""identifier"":""" + id3 + @""",
				 ""name"":""Ramo Dictionary"",
				 ""repository"":""http:\/\/public.languageforge.org"",
				 ""role"":""unknown""
			}]";

			var m = new ServerSettingsModel();

			// SUT
			m.PopulateAvailableProjects(json);

			Assert.AreEqual(3, m.AvailableProjects.Count, "number of available projects");
			CollectionAssert.Contains(m.AvailableProjects, id1);
			CollectionAssert.Contains(m.AvailableProjects, id2);
			CollectionAssert.Contains(m.AvailableProjects, id3);
		}

		[Test]
		public void PopulateAvailableProjects_ToleratesMissingProperties()
		{
			const string id = "nko";
			const string json = @"[{
				 ""identifier"":""" + id + @"""
			}]";

			var m = new ServerSettingsModel();

			// SUT
			m.PopulateAvailableProjects(json);

			Assert.AreEqual(1, m.AvailableProjects.Count, "number of available projects");
			CollectionAssert.Contains(m.AvailableProjects, id);
		}

		[Test]
		[Ignore("not working yet")]
		public void PopulateAvailableProjects_ToleratesExtraProperties()
		{
			const string id = "nko";
			const string json = @"[{
				 ""identifier"":""" + id + @"""
				 ""name"":""Nkonya 2011"",
				 ""repository"":""http:\/\/public.languageforge.org"",
				 ""role"":""unknown""
				 ""owner"":""nko-admin""
			}]";

			var m = new ServerSettingsModel();

			// SUT
			m.PopulateAvailableProjects(json);

			Assert.AreEqual(1, m.AvailableProjects.Count, "number of available projects");
			CollectionAssert.Contains(m.AvailableProjects, id);
		}

		[Test]
		public void PopulateAvailableProjects_NoProjects([Values("", "[]")] string json)
		{
			var m = new ServerSettingsModel();

			// SUT
			m.PopulateAvailableProjects(json);

			CollectionAssert.IsEmpty(m.AvailableProjects);
		}

		[Test]
		public void PopulateAvailableProjects_ThrowsBadJson()
		{
			const string badJson = @"[{""identifier"":(}]";
			var m = new ServerSettingsModel();

			// SUT
			Assert.Throws<JsonReaderException>(() => m.PopulateAvailableProjects(badJson));
		}

		[Test]
		public void SaveSettings_NoHgFolderExists_CreatesOneWithCorrectPath()
		{
			using (var folder = new TemporaryFolder("ServerSettingsModel"))
			{
				const string user = "joe";
				const string pass = "pass";
				const string host = "hg-public.languageforge.org/tpi";
				const string url = "https://" + user + ":" + pass + "@" + host;
				var m = new ServerSettingsModel();
				m.InitFromProjectPath(folder.Path);
				m.SetUrlToUseIfSettingsAreEmpty(url);
				m.SaveSettings();
				Assert.IsTrue(Directory.Exists(folder.Combine(".hg")));
				Assert.IsTrue(File.Exists(folder.Combine(".hg","hgrc")));
				var repo = HgRepository.CreateOrUseExisting(folder.Path, new NullProgress());
				var address = repo.GetDefaultNetworkAddress<HttpRepositoryPath>();
				Assert.AreEqual(new ServerSettingsModel.BandwidthItem(ServerSettingsModel.BandwidthEnum.High), m.Bandwidth);
				Assert.AreEqual("https://" + host, address.URI);
				Assert.AreEqual(user, m.Username);
				Assert.AreEqual(pass, m.Password);
			}
		}

		[Test]
		public void SaveSettings_PreexistsAndWeSave_RemovesPassword()
		{
			using (var folder = new TemporaryFolder("ServerSettingsModel"))
			{
				// Precondition is some url that is not our default from the ServerSettingsModel
				var original = HgRepository.CreateOrUseExisting(folder.Path, new NullProgress());
				original.SetKnownRepositoryAddresses(new[]
				{
					new HttpRepositoryPath("languageForge.org [legacy sync]", "https://joe:oldPassword@hg-public.languageforge.org/tpi", false, null, null)
				});

				var m = new ServerSettingsModel();
				m.InitFromProjectPath(folder.Path);
				m.SaveSettings();
				Assert.IsTrue(Directory.Exists(folder.Combine(".hg")));
				Assert.IsTrue(File.Exists(folder.Combine(".hg", "hgrc")));
				var repo = HgRepository.CreateOrUseExisting(folder.Path, new NullProgress());
				var address = repo.GetDefaultNetworkAddress<HttpRepositoryPath>();
				Assert.AreEqual("https://hg-public.languageforge.org/tpi", address.URI);
				Assert.AreEqual("https://hg-public.languageforge.org/tpi", address.GetPotentialRepoUri(null, null, null));
				Assert.AreEqual(null, address.Password);
			}
		}

		[Test]
		public void SetUrlToUseIfSettingsAreEmpty_RepoAlreadyExistsWithAServerAddress_IgnoresOfferedUrl()
		{
			using (var folder = new TemporaryFolder("ServerSettingsModel"))
			{
				var original = HgRepository.CreateOrUseExisting(folder.Path, new NullProgress());
				var existing = "https://abc.com";
				original.SetKnownRepositoryAddresses(new[] { new HttpRepositoryPath("languageforge.org [Safe Mode]", existing, false) });

				var m = new ServerSettingsModel();
				var url = "https://joe:pass@hg-public.languageforge.org/tpi";
				m.InitFromProjectPath(folder.Path);
				m.SetUrlToUseIfSettingsAreEmpty(url);
				Assert.AreEqual(existing, m.URL);
			}
		}

		/// <summary>
		/// We want disk URLs identified as 'default' to be ignored (since they are not ones we added ourselves)
		/// </summary>
		[Test]
		public void DefaultUrlsAreIgnored()
		{
			using (var folder = new TemporaryFolder("ServerSettingsModel"))
			{
				var original = HgRepository.CreateOrUseExisting(folder.Path, new NullProgress());
				original.SetKnownRepositoryAddresses(new[] { new HttpRepositoryPath("default", "c://abc.com", false) });

				var m = new ServerSettingsModel();
				var url = "c://joe:pass@hg-public.languageforge.org/tpi";
				m.InitFromProjectPath(folder.Path);
				m.SetUrlToUseIfSettingsAreEmpty(url);
				Assert.AreEqual(url, m.URL);
			}
		}

		/// <summary>
		/// The new default (as of 8 Nov 2012) is resumable.
		/// </summary>
		[Test]
		public void DefaultIsResumable()
		{
			var m = new ServerSettingsModel();
			Assert.AreEqual("resumable.languageforge.org", m.Host);
		}

		[Test]
		public void EncryptPassword_NullAndEmptyDoNotCrash()
		{
			Assert.DoesNotThrow(() => ServerSettingsModel.EncryptPassword(null));
			Assert.DoesNotThrow(() => ServerSettingsModel.EncryptPassword(string.Empty));
		}

		[Test]
		public void DecryptPassword_NullAndEmptyDoNotCrash()
		{
			Assert.DoesNotThrow(() => ServerSettingsModel.DecryptPassword(null));
			Assert.DoesNotThrow(() => ServerSettingsModel.DecryptPassword(string.Empty));
		}

		[Test]
		public void EncryptPassword_RoundTrips()
		{
			const string password = "P@55w0rd";
			var encrypted = ServerSettingsModel.EncryptPassword(password);
			var decrypted = ServerSettingsModel.DecryptPassword(encrypted);
			Assert.AreEqual(password, decrypted);
			Assert.AreNotEqual(password, encrypted);
		}
	}
}