﻿using System;

namespace Chorus.merge
{
	/// <summary>
	/// gives information about a change in a file, e.g. a dictionary entry that was changed.
	/// Note that converting this raw info into human-readable, type-sensitive display
	/// is the reponsibility of implementers of IChangePresenter
	/// </summary>
	public interface IChangeReport
	{
		Guid  Guid { get; }
		string GetFullHumanReadableDescription();
		string ActionLabel { get; }
		string PathToFile { get; }
		string UrlOfItem { get; }
	}
}
