﻿using JocysCom.ClassLibrary.Controls.IssuesControl;
using System;
using System.IO;
using x360ce.Engine;

namespace x360ce.App.Issues
{
    public class CppX64RuntimeInstallIssue : IssueItem
	{

		public CppX64RuntimeInstallIssue() : base()
		{
			Name = program + " Installation";
			FixName = "Fix";
		}

        string program = "Visual C++ 2015 Redistributable (x64)";

        public override void CheckTask()
		{
            // This isse check applies only for 64-bit OS.
            if (!Environment.Is64BitOperatingSystem)
            {
                SetSeverity(IssueSeverity.None);
                return;
            }
			var installed = IssueHelper.IsInstalled(program, false);
			if (!installed)
			{
				SetSeverity(
					IssueSeverity.Critical, 1,
					string.Format("Install "+ program)
				);
				return;
			}
			SetSeverity(IssueSeverity.None);
		}

		public override void FixTask()
		{
            // Microsoft Visual C++ 2015 Redistributable Update 3
            EngineHelper.OpenUrl("https://www.microsoft.com/en-us/download/details.aspx?id=53587");
        }
    }
}