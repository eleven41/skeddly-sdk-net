using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class AzureActionParameters : ActionParameters
	{
		public IEnumerable<string> CredentialIds { get; set; }
		public IEnumerable<string> LocationNames { get; set; }
	}

	public class ResourceGroupNameComparison
	{
		public string CompareType { get; set; }
		public string ResourceGroupName { get; set; }
	}

	public class VirtualMachineNameComparison
	{
		public string CompareType { get; set; }
		public string VirtualMachineName { get; set; }
	}

	public class AzureStartVirtualMachinesParameters : AzureActionParameters
	{
		public ResourceGroupNameComparison ResourceGroupNameComparison { get; set; }
		public VirtualMachineNameComparison VirtualMachineNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int? StopTimeInSeconds { get; set; }
	}

	public class AzureStopVirtualMachinesParameters : AzureActionParameters
	{
		public ResourceGroupNameComparison ResourceGroupNameComparison { get; set; }
		public VirtualMachineNameComparison VirtualMachineNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int? RestartTimeInSeconds { get; set; }
		public string RestartTimeFrame { get; set; }
	}

	public class AzureBackupVirtualMachinesParameters : AzureActionParameters
	{
		public ResourceGroupNameComparison ResourceGroupNameComparison { get; set; }
		public VirtualMachineNameComparison VirtualMachineNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string ConsistencyMethod { get; set; }

		public string TargetResourceGroupName { get; set; }
		public string SnapshotName { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
	}

	public class DiskSnapshotNameComparison
	{
		public string CompareType { get; set; }
		public string SnapshotName { get; set; }
	}

	public class AzureDeleteDiskSnapshotsParameters : AzureActionParameters
	{
		public ResourceGroupNameComparison ResourceGroupNameComparison { get; set; }
		public DiskSnapshotNameComparison SnapshotNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DeleteScheme { get; set; }
		public FirstInFirstOutDeleteSchemeParameters FirstInFirstOutParameters { get; set; }
		public GrandfatherFatherSonDeleteSchemeParameters GrandfatherFatherSonParameters { get; set; }

		public string GroupingMethod { get; set; }
		public string GroupingResourceTagName { get; set; }

		public string TargetType { get; set; }
		public IEnumerable<string> TargetEmails { get; set; }
		public string ReportFormat { get; set; }

		public bool IsTest { get; set; }
	}
}
