using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class AmazonActionParameters : ActionParameters
	{
		public IEnumerable<string> CredentialIds { get; set; }
		public IEnumerable<string> RegionNames { get; set; }
	}

	public class Tag
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}

	public class AmazonAddSecurityGroupRuleParameters : AmazonActionParameters
	{
		public string Direction { get; set; }
		public string Protocol { get; set; }
		public int FromPort { get; set; }
		public int ToPort { get; set; }

		public string SecurityGroup { get; set; }
		public string SourceType { get; set; }
		public string Source { get; set; }
		public string RegisterMultipleDnsEntries { get; set; }

		public int? RevokeTimeInSeconds { get; set; }
	}

	public class AmazonAssociateElasticIpParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string ElasticIpAddress { get; set; }
	}

	public class AmazonBackupRoute53HostedZoneParameters : AmazonActionParameters
	{
		public string HostedZoneName { get; set; }
		public string BucketName { get; set; }
		public string ObjectKey { get; set; }
		public string ExportFormat { get; set; }
	}

	public class AmazonBackupEc2InstanceParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string SnapshotName { get; set; }
		public string Description { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public IEnumerable<Tag> Tags { get; set; }
		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class RollingInstanceStops
	{
		public string Method { get; set; }
		public string ResourceTagName { get; set; }
		public int DelaySeconds { get; set; }
		public bool IsWaitForStatus { get; set; }
	}

	public class AmazonBackupEc2InstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }

		public IEnumerable<string> InstanceIds { get; set; }

		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public RollingInstanceStops RollingInstanceStops { get; set; }

		public string SnapshotName { get; set; }
		public string Description { get; set; }

		public IEnumerable<Tag> Tags { get; set; }
		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmazonBackupRoute53HostedZonesParameters : AmazonActionParameters
	{
		public string HostedZoneIdentificationMethod { get; set; }

		public IEnumerable<string> HostedZoneNames { get; set; }

		public string BucketName { get; set; }
		public string ObjectKey { get; set; }
		public string ExportFormat { get; set; }
	}

	public class AmazonS3Target
	{
		public string BucketName { get; set; }
		public string ObjectKey { get; set; }
		public string EncryptionType { get; set; }
	}

	public class SpecificDatabases
	{
		public IEnumerable<string> Databases { get; set; }
	}

	public class AllDatabases
	{
		public bool IsSeparateDatabases { get; set; }
	}

	public class SpotInstanceOptions
	{
		public decimal MaxSpotPrice { get; set; }
	}

	public class DatabaseEndpoint
	{
		public string Endpoint { get; set; }
		public int Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class AmazonBackupMySQLServerParameters : AmazonActionParameters
	{
		public string EngineVersion { get; set; }

		public string AvailabilityZone { get; set; }
		public string InstanceType { get; set; }
		public string SecurityGroup { get; set; }
		public string SubnetId { get; set; }
		public string PrivateIpAddress { get; set; }
		public int? VolumeSize { get; set; }

		public SpotInstanceOptions SpotInstanceOptions { get; set; }

		public string EndpointMethod { get; set; }

		public DatabaseEndpoint DatabaseEndpoint { get; set; }

		public string Databases { get; set; }
		public SpecificDatabases SpecificDatabases { get; set; }
		public AllDatabases AllDatabases { get; set; }

		public string ExtraCommandLineArguments { get; set; }
		public bool IsOmitDatabasesFlag { get; set; }

		public string TargetType { get; set; }

		public AmazonS3Target AmazonS3Target { get; set; }
	}

	public class AmazonChangeEc2InstanceTypeParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string DeregisterFromLoadBalancers { get; set; }

		public string InstanceType { get; set; }
		public bool? IsEbsOptimized { get; set; }

		public int? RevertTimeInSeconds { get; set; }

	}

	public class AmazonChangeRdsInstanceClassParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string DbInstanceId { get; set; }

		public string DbInstanceClass { get; set; }

		public int? RevertTimeInSeconds { get; set; }
	}

	public class AmiImageNameComparison
	{
		public string ImageName { get; set; }
		public string CompareType { get; set; }
	}

	public class AmazonCopyAmiImagesParameters : AmazonActionParameters
	{
		public string ImageIdentificationMethod { get; set; }
		public IEnumerable<string> ImageIds { get; set; }

		public AmiImageNameComparison ImageNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int? NewerThanInDays { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }

		public string Description { get; set; }
		public string ImageName { get; set; }

		public string ConflictResolutionMethod { get; set; }

		public bool IsCopyTags { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public bool IsCopyImagePermissions { get; set; }
		public bool IsCopySnapshotPermissions { get; set; }
	}

	public class AmazonCopyAmiToRegionParameters : AmazonActionParameters
	{
	}

	public class AmazonCopyEbsSnapshotsParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }

		public string SnapshotId { get; set; }
		public string VolumeId { get; set; }

		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }

		public int? NewerThanInDays { get; set; }

		public bool IsCopyTags { get; set; }

		public bool IsPreventDuplicates { get; set; }

		public IEnumerable<Tag> Tags { get; set; }
	}

	public class AmazonCopyEbsVolumeParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public string VolumeId { get; set; }
		public string ConsistencyMethod { get; set; }

		public AttachVolumeToInstanceParameters AttachToInstance { get; set; }
	}

	public class AttachVolumeToInstanceParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string DeviceName { get; set; }
		public bool IsDetachExistingDevice { get; set; }
		public bool IsStopInstance { get; set; }
	}

	public class AmazonCopyEc2InstanceParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }

		public string AvailabilityZone { get; set; }

		public string CopyMethod { get; set; }

		public bool IsStopInstance { get; set; }
		public bool IsTransferElasticIp { get; set; }

		public string SecurityGroupOverride { get; set; }
		public string SubnetIdOverride { get; set; }
		public string InstanceTypeOverride { get; set; }
		public string IamInstanceProfileOverride { get; set; }

		public string TargetCredentialId { get; set; }

		public bool IsDeleteAmi { get; set; }
	}

	public class InstanceNameComparison
	{
		public string InstanceName { get; set; }
		public string CompareType { get; set; }
	}

	public class ResourceTagComparison
	{
		public string TagName { get; set; }
		public string CompareType { get; set; }
		public string TagValue { get; set; }
	}

	public class RdsSnapshotIdComparison
	{
		public string CompareType { get; set; }
		public string SnapshotId { get; set; }
	}

	public class AmazonCopyRdsSnapshotsParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }
		public RdsSnapshotIdComparison SnapshotIdComparison { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string SnapshotType { get; set; }
		public string AccountNumber { get; set; }

		public string NewSnapshotId { get; set; }
		public bool IsCopyTags { get; set; }
		public int? NewerThanInDays { get; set; }
		public string ConflictResolutionMethod { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
		public string TargetKmsKeyOverride { get; set; }
		public string TargetOptionGroupName { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmazonCopyS3ObjectsParameters : AmazonActionParameters
	{
		public string SourceBucketName { get; set; }
		public string SourcePrefix { get; set; }

		public string TargetBucketName { get; set; }

		public string RenameMethod { get; set; }
		public string TargetPrefix { get; set; }

		public string OverwriteRule { get; set; }

		public string StorageClass { get; set; }
		public string AclSettings { get; set; }
	}

	public class AmazonCreateAmiImagesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }

		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }
		public string ImageName { get; set; }

		public string ConsistencyMethod { get; set; }

		public string SetImageNameTagMethod { get; set; }
		public string CustomImageNameTag { get; set; }

		public string SetSnapshotNameTagMethod { get; set; }
		public string CustomSnapshotNameTag { get; set; }

		public IEnumerable<AmiImageTag> Tags { get; set; }

		public AmiImageVolumeChanges VolumeChanges { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
		public string TargetKmsKeyIdOverride { get; set; }
	}

	public class AmiImageTag
	{
		public string Key { get; set; }
		public string Value { get; set; }

		public bool AddToImage { get; set; }
		public bool AddToSnapshots { get; set; }
	}

	public class AmazonCreateDirectoryServiceSnapshotsParameters : AmazonActionParameters
	{
		public string DirectoryIdentificationMethod { get; set; }
		public IEnumerable<string> DirectoryIds { get; set; }
		public IEnumerable<string> DirectoryNames { get; set; }

		public string SnapshotName { get; set; }
	}

	public class AmazonCreateEbsSnapshotsParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public IEnumerable<string> VolumeIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }
		public string SnapshotName { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmazonCreateElastiCacheClusterParameters : AmazonActionParameters
	{
		public string ClusterId { get; set; }
		public string Engine { get; set; }
		public string EngineVersion { get; set; }

		public string NodeType { get; set; }
		public int NumNodes { get; set; }

		public string AvailabilityZone { get; set; }
		public string SubnetGroupName { get; set; }
		public string SecurityGroup { get; set; }
		public string ParameterGroupName { get; set; }

		public int? SnapshotRetentionLimitInDays { get; set; }
		public string ReplicationGroupId { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
	}

	public class AmazonCreateElastiCacheReadReplicaParameters : AmazonActionParameters
	{
		public string ClusterId { get; set; }
		public string ReplicationGroupId { get; set; }
		public string AvailabilityZone { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
	}

	public class ElastiCacheClusterIdComparison
	{
		public string CompareType { get; set; }
		public string ClusterId { get; set; }
	}


	public class AmazonCreateElastiCacheSnapshotsParameters : AmazonActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public ElastiCacheClusterIdComparison ClusterIdComparison { get; set; }

		public string SnapshotId { get; set; }
	}

	public class AmiImageVolumeChanges
	{
		public string VolumesToInclude { get; set; }
		public string ChangeVolumeType { get; set; }
		public int? ChangeIops { get; set; }
		public bool? ChangeIsDeleteOnTerminate { get; set; }
	}

	public class AmazonCreateAmiImageParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string Description { get; set; }
		public string ImageName { get; set; }

		public string ConsistencyMethod { get; set; }

		public string SetImageNameTagMethod { get; set; }
		public string CustomImageNameTag { get; set; }
		public string SetSnapshotNameTagMethod { get; set; }
		public string CustomSnapshotNameTag { get; set; }

		public IEnumerable<AmiImageTag> Tags { get; set; }

		public AmiImageVolumeChanges VolumeChanges { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmazonCreateRdsReadReplicaParameters : AmazonActionParameters
	{
		public string DbInstanceId { get; set; }
		public string ReplicaId { get; set; }
		public string AvailabilityZone { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
	}

	public class AmazonCreateRdsSnapshotParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string DbInstanceId { get; set; }
		public string SnapshotId { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class CreateRdsSnapshotsParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string SnapshotId { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
		public string TargetKmsKeyOverride { get; set; }
	}

	public class AmazonCreateRedshiftSnapshotParameters : AmazonActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public string ClusterId { get; set; }

		public string SnapshotId { get; set; }

		public IEnumerable<Tag> Tags { get; set; }
	}

	public class AmazonCreateEbsSnapshotParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public string VolumeId { get; set; }

		public string Description { get; set; }
		public string SnapshotName { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class DeleteDirectoryServiceSnapshotsComparison
	{
		public string Field { get; set; }
		public string ResourceTagName { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
	}

	public class DeleteDirectoryServiceSnapshotsParameters : AmazonActionParameters
	{
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }

		public bool IsPerDirectory { get; set; }

		public DeleteDirectoryServiceSnapshotsComparison DeleteComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteDynamoDbItemsParameters : AmazonActionParameters
	{
		public string TableName { get; set; }
		public string DateAttribute { get; set; }
		public int OlderThanDays { get; set; }
		public string DateType { get; set; }
		public int ScanLimit { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteElastiCacheClustersParameters : AmazonActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public ElastiCacheClusterIdComparison ClusterIdComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteElastiCacheSnapshotsComparison
	{
		public string Field { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
	}

	public class DeleteElastiCacheSnapshotsParameters : AmazonActionParameters
	{
		public DeleteElastiCacheSnapshotsComparison DeleteComparison { get; set; }
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }

		public bool IsTest { get; set; }
	}

	public class RdsInstanceIdComparison
	{
		public string CompareType { get; set; }
		public string DbInstanceId { get; set; }
	}

	public class DeleteRdsInstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string FinalSnapshotId { get; set; }

		public bool IsTest { get; set; }
	}

	public class RdsSourceIdComparison
	{
		public string CompareType { get; set; }
		public string SourceId { get; set; }
	}

	public class AmazonDeleteRdsSnapshotsParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }

		public RdsSnapshotIdComparison SnapshotIdComparison { get; set; }
		public RdsSourceIdComparison SourceIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DeleteScheme { get; set; }

		public FirstInFirstOutDeleteSchemeParameters FirstInFirstOutParameters { get; set; }
		public GrandfatherFatherSonDeleteSchemeParameters GrandfatherFatherSonParameters { get; set; }

		public string GroupingMethod { get; set; }
		public string GroupingResourceTagName { get; set; }

		public bool? IsIncludeClusterSnapshots { get; set; }

		public bool IsTest { get; set; }
	}

	public class RedshiftClusterIdComparison
	{
		public string CompareType { get; set; }
		public string ClusterId { get; set; }
	}

	public class DeleteRedshiftClustersParameters : AmazonActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public RedshiftClusterIdComparison ClusterIdComparison { get; set; }

		public string FinalSnapshotId { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteRedshiftSnapshotsComparison
	{
		public string Field { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
	}

	public class DeleteRedshiftSnapshotsParameters : AmazonActionParameters
	{
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }

		public DeleteRedshiftSnapshotsComparison DeleteComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteS3ObjectsComparison
	{
		public string Field { get; set; }
		public string MetadataKey { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
	}

	public class DeleteS3ObjectsParameters : AmazonActionParameters
	{
		public string BucketName { get; set; }
		public string Prefix { get; set; }
		public int? OlderThanDays { get; set; }

		public DeleteS3ObjectsComparison DeleteComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class FirstInFirstOutDeleteSchemeParameters
	{
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }
	}

	public class SnapshotNameComparison
	{
		public string CompareType { get; set; }
		public string SnapshotName { get; set; }
	}

	public class EbsSnapshotDescriptionComparison
	{
		public string CompareType { get; set; }
		public string Description { get; set; }
	}

	public class EbsVolumeIdComparison
	{
		public string CompareType { get; set; }
		public string VolumeId { get; set; }
	}

	public class MinimumToKeepPeriodParameters
	{
		public int MinimumToKeep { get; set; }
		public int? NumPeriods { get; set; }
	}

	public class GrandfatherFatherSonDeleteSchemeParameters
	{
		public MinimumToKeepPeriodParameters Days { get; set; }
		public MinimumToKeepPeriodParameters Weeks { get; set; }
		public MinimumToKeepPeriodParameters Months { get; set; }
		public MinimumToKeepPeriodParameters Years { get; set; }
	}

	public class AmazonDeleteEbsSnapshotsParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }

		public EbsSnapshotDescriptionComparison SnapshotDescriptionComparison { get; set; }
		public NameTagComparison SnapshotNameTagComparison { get; set; }
		public EbsVolumeIdComparison VolumeIdComparison { get; set; }
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

	public class NameTagComparison
	{
		public string CompareType { get; set; }
		public string NameTag { get; set; }
	}

	public class AmiImageDescriptionComparison
	{
		public string CompareType { get; set; }
		public string Description { get; set; }
	}

	public class AmazonDeregisterAmiImagesParameters : AmazonActionParameters
	{
		public string ImageIdentificationMethod { get; set; }

		public AmiImageDescriptionComparison ImageDescriptionComparison { get; set; }
		public AmiImageNameComparison ImageNameComparison { get; set; }
		public NameTagComparison NameTagComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DeregisterSharedImages { get; set; }
		public string DeleteScheme { get; set; }

		public FirstInFirstOutDeleteSchemeParameters FirstInFirstOutParameters { get; set; }
		public GrandfatherFatherSonDeleteSchemeParameters GrandfatherFatherSonParameters { get; set; }
		
		public string GroupingMethod { get; set; }
		public string GroupingResourceTagName { get; set; }

		public bool? IsDeleteSnapshots { get; set; }
		public bool? IsDeleteFromS3 { get; set; }

		public string TargetType { get; set; }
		public IEnumerable<string> TargetEmails { get; set; }
		public string ReportFormat { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeregisterInstanceFromLoadBalancerParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }

		public string DeregisterMethod { get; set; }
		public string LoadBalancerName { get; set; }
	}

	public class ExportEc2InstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public string BucketName { get; set; }
		public string Prefix { get; set; }

		public string TargetEnvironment { get; set; }
		public string DiskImageFormat { get; set; }
	}

	public class GenerateIamCredentialReportParameters : AmazonActionParameters
	{
	}

	public class GrowEbsVolumeParameters : AmazonActionParameters
	{
		public string GrowVolumeMethod { get; set; }
		public string InstanceId { get; set; }
		public string DeviceName { get; set; }
		public string VolumeId { get; set; }

		public int SizeValue { get; set; }
		public string SizeType { get; set; }

		public bool IsStopInstance { get; set; }
		public bool IsCopyTags { get; set; }

		public bool IsDeleteOldVolume { get; set; }
		public bool IsDeleteSnapshot { get; set; }

		public string DeleteOnTerminate { get; set; }
	}

	public class InvokeLambdaFunctionParameters : AmazonActionParameters
	{
		public string FunctionName { get; set; }
		public string Arguments { get; set; }
	}

	public class LaunchInstanceParameters : AmazonActionParameters
	{
		public string ImageIdentificationMethod { get; set; }
		public string AmiImageId { get; set; }
		public AmiImageNameComparison ImageNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int MinNumber { get; set; }
		public int MaxNumber { get; set; }

		public string InstanceType { get; set; }
		public string AvailabilityZone { get; set; }
		public string VpcSubnetId { get; set; }

		public string PrivateIpAddress { get; set; }
		public string ElasticIp { get; set; }

		public string SecurityGroup { get; set; }

		public string PlacementGroupName { get; set; }
		public string KernelId { get; set; }
		public string RamdiskId { get; set; }
		public string KeyName { get; set; }
		public bool IsMonitoring { get; set; }

		public string UserData { get; set; }

		public string InstanceName { get; set; }
		public string LoadBalancerName { get; set; }
		public string IamInstanceProfileName { get; set; }
		public string DirectoryServiceDomain { get; set; }

		public int? TerminateTimeInSeconds { get; set; }
	}

	public class ModifyS3ObjectsParameters : AmazonActionParameters
	{
		public string BucketName { get; set; }
		public string Prefix { get; set; }
		public string ServerSideEncryptionType { get; set; }
		public string StorageClass { get; set; }
	}

	public class PublishSnsMessageParameters : AmazonActionParameters
	{
		public string SnsTopicArn { get; set; }

		public string PublishType { get; set; }
		public string Subject { get; set; }

		public SimpleMessage SimpleMessage { get; set; }
		public RawMessage RawMessage { get; set; }
		public ProtocolSpecificMessage ProtocolSpecificMessage { get; set; }
	}

	public class SimpleMessage
	{
		public string Message { get; set; }
	}

	public class RawMessage
	{
		public string Message { get; set; }
		public string MessageStructure { get; set; }
	}

	public class ProtocolSpecificMessage
	{
		public string DefaultMessage { get; set; }
		public string EmailMessage { get; set; }
		public string SqsMessage { get; set; }
		public string SmsMessage { get; set; }
		public string HttpMessage { get; set; }
		public string HttpsMessage { get; set; }
	}

	public class RebootElastiCacheClustersParameters : AmazonActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public ElastiCacheClusterIdComparison ClusterIdComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class RebootInstanceParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
	}

	public class RebootRdsInstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }

		public bool IsForceFailover { get; set; }
	}

	public class RegisterInstanceWithLoadBalancerParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }

		public string LoadBalancerName { get; set; }

		public int? DeregisterTimeInSeconds { get; set; }
	}

	public class AmazonRequestEc2SpotInstancesParameters : AmazonActionParameters
	{
		public string ImageIdentificationMethod { get; set; }

		public string ImageId { get; set; }
		public AmiImageDescriptionComparison ImageDescriptionComparison { get; set; }
		public AmiImageNameComparison ImageNameComparison { get; set; }
		public NameTagComparison NameTagComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string InstanceType { get; set; }
		public string AvailabilityZone { get; set; }

		public decimal MaxSpotPriceUsd { get; set; }
		public int MaxInstanceCount { get; set; }

		public string VpcSubnetId { get; set; }
		public string SecurityGroup { get; set; }
		public string KeyPair { get; set; }

		public string UserData { get; set; }
		public string UserDataFormat { get; set; }

		public string ElasticIp { get; set; }
		public string IamInstanceProfile { get; set; }

		public int? CancelTimeInSeconds { get; set; }

		public int? TerminateTimeInSeconds { get; set; }
		public string TerminateTimeFrame { get; set; }
	}

	public class ResizeRedshiftClusterParameters : AmazonActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public string ClusterId { get; set; }

		public string NodeType { get; set; }
		public int? NumNodes { get; set; }

		public int? RevertTimeInSeconds { get; set; }
	}

	public class ResourceReportParameters : AmazonActionParameters
	{
		public IEnumerable<string> ResourceToInclude { get; set; }
		public string TargetType { get; set; }
	}

	public class RestoreRdsInstanceParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }
		public string SnapshotId { get; set; }
		public string DbInstanceId { get; set; }

		public string NewDbInstanceId { get; set; }
		public string DuplicateInstanceResolutionMethod { get; set; }
		public string DbInstanceClass { get; set; }
		public bool? IsMultiAz { get; set; }
		public string AvailabilityZone { get; set; }

		public string DbSubnetGroupName { get; set; }
		public IEnumerable<string> SecurityGroups { get; set; }
		public string DbParameterGroupName { get; set; }
		public string OptionGroupName { get; set; }
		public string StorageType { get; set; }

		public string ChangeIops { get; set; }
		public int? NewIops { get; set; }

		public string ChangeBackupRetentionPeriod { get; set; }
		public int? NewBackupRetentionDays { get; set; }

		public string ChangePubliclyAccessible { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
		public string FinalSnapshotId { get; set; }
	}

	public class RestoreRedshiftClusterParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }
		public string SnapshotId { get; set; }
		public string ClusterId { get; set; }

		public string NewClusterId { get; set; }

		public string AvailabilityZone { get; set; }
		public string ClusterSubnetGroupName { get; set; }
		public string SecurityGroup { get; set; }
		public string ClusterParameterGroupName { get; set; }
		public bool? IsPubliclyAccessible { get; set; }
		public bool? IsEnhancedVpcRouting { get; set; }
		public IEnumerable<string> IamRoles { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
		public string FinalSnapshotId { get; set; }
	}

	public class RunningTimeReportParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int MinimumMinutesForBreak { get; set; }

		public string TimePeriod { get; set; }
		public int? TimePeriodDays { get; set; }
	}

	public class AmazonStartEc2InstanceParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string ElasticIp { get; set; }
		public string LoadBalancerName { get; set; }
		public string ResumeAutoScalingProcesses { get; set; }

		public bool IsCheckReachability { get; set; }
		public bool IsSendEmailOnReachabilityFailure { get; set; }

		public int? StopTimeInSeconds { get; set; }
	}

	public class AmazonStartEc2InstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<StartEc2InstancesInstance> Instances { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string LoadBalancerName { get; set; }
		public string ResumeAutoScalingProcesses { get; set; }

		public bool IsCheckReachability { get; set; }
		public bool IsSendEmailOnReachabilityFailure { get; set; }

		public int? StopTimeInSeconds { get; set; }
	}

	public class StartEc2InstancesInstance
	{
		public string InstanceId { get; set; }
		public string ElasticIp { get; set; }
	}

	public class StartSwfWorkflowExecutionParameters : AmazonActionParameters
	{
		public string Domain { get; set; }
		public string WorkflowTypeName { get; set; }
		public string WorkflowTypeVersion { get; set; }
		public string WorkflowExecutionId { get; set; }
		public string Input { get; set; }
		public string TaskListName { get; set; }

		public IEnumerable<string> WorkflowTags { get; set; }
	}

	public class StopInstanceParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public bool IsForceStop { get; set; }
		public string SuspendAutoScalingProcesses { get; set; }

		public int? RestartTimeInSeconds { get; set; }
		public string RestartTimeFrame { get; set; }
	}

	public class StopMultipleInstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string StopLimit { get; set; }
		public int? StopLimitValue { get; set; }

		public bool IsForceStop { get; set; }
		public string SuspendAutoScalingProcesses { get; set; }

		public int? RestartTimeInSeconds { get; set; }
		public string RestartTimeFrame { get; set; }
	}

	public class TerminateInstanceParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }
	}

	public class UpdateAutoScalingGroupParameters : AmazonActionParameters
	{
		public string GroupName { get; set; }
		public string LaunchConfigurationName { get; set; }

		public int? MinSize { get; set; }
		public int? MaxSize { get; set; }
		public int? DesiredSize { get; set; }

		public int? RestoreTimeInSeconds { get; set; }
	}

	public class UpdateRoute53RecordParameters : AmazonActionParameters
	{
		public string HostedZoneName { get; set; }
		public string RecordName { get; set; }
		public string RecordType { get; set; }

		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
	}

	public class AmazonCreateCloudFormationStackParameters : AmazonActionParameters
	{
		public string StackName { get; set; }
		public string TemplateFormat { get; set; }
		public string TemplateBody { get; set; }
		public string TemplateUrl { get; set; }
		public string TemplateBucketName { get; set; }
		public string TemplateObjectKey { get; set; }
		
		public IEnumerable<CloudFormationParameter> Parameters { get; set; }
		public IEnumerable<string> Capabilities { get; set; }
		public IEnumerable<Tag> Tags { get; set; }

		public int? TimeoutInMinutes { get; set; }
		public string FailureBehaviour { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
	}

	public class CloudFormationParameter
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public bool UsePreviousValue { get; set; }
	}

	public class DeleteCloudFormationStacksParameters : AmazonActionParameters
	{
		public string StackIdentificationMethod { get; set; }
		public StackNameComparison StackNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int? OlderThanDays { get; set; }
		public int? DaysSinceLastUpdate { get; set; }

		public bool IsTest { get; set; }
	}

	public class StackNameComparison
	{
		public string StackName { get; set; }
		public string CompareType { get; set; }
	}

	public class AmazonChangeDynamoDbTablesParameters : AmazonActionParameters
	{
		public string TableIdentificationMethod { get; set; }
		public TableNameComparison TableNameComparison { get; set; }

		public long? ReadCapacity { get; set; }
		public long? WriteCapacity { get; set; }

		public int? RevertTimeInSeconds { get; set; }
	}

	public class TableNameComparison
	{
		public string TableName { get; set; }
		public string CompareType { get; set; }
	}

	public class CreateStorageGatewaySnapshotsParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public GatewayNameComparison GatewayNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }
		public string SnapshotName { get; set; }
		public IEnumerable<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
	}

	public class GatewayNameComparison
	{
		public string GatewayName { get; set; }
		public string CompareType { get; set; }
	}

	public class EraseDeletedS3ObjectsParameters : AmazonActionParameters
	{
		public string BucketName { get; set; }
		public string Prefix { get; set; }

		public bool IsTest { get; set; }
	}

	public class AmazonSendSsmCommandParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }

		public IEnumerable<string> InstanceIds { get; set; }

		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DocumentName { get; set; }

		public IEnumerable<SendSsmCommandParameter> CommandParameters { get; set; }

		public int? TimeoutInSeconds { get; set; }
	}

	public class SendSsmCommandParameter
	{
		public string ParameterName { get; set; }
		public IEnumerable<string> Values { get; set; }
	}

	public class AmazonDeleteEbsVolumesParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public IEnumerable<string> VolumeIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public DaysDetached DaysDetached { get; set; }
		public CreateEbsSnapshot CreateEbsSnapshot { get; set; }

		public string TargetType { get; set; }
		public IEnumerable<string> TargetEmails { get; set; }
		public string ReportFormat { get; set; }

		public bool IsTest { get; set; }
	}

	public class CreateEbsSnapshot
	{
		public string Description { get; set; }
		public string SnapshotName { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
	}

	public class DaysDetached
	{
		public int NumDays { get; set; }
		public string ResourceTagName { get; set; }
	}

	public class RebootEc2InstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
	}

	public class TerminateEc2InstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }

		public int? OlderThanDays { get; set; }
		public IEnumerable<string> InstanceStates { get; set; }

		public int? MinimumToKeep { get; set; }
		public RandomTermination RandomTermination { get; set; }

		public CreateAmiImage CreateAmiImage { get; set; }

		public bool IsDisableTerminationProtection { get; set; }

		public bool IsTest { get; set; }
	}

	public class RandomTermination
	{
		public int ProbabilityToTerminatePercentage { get; set; }
		public int? MinimumToTerminate { get; set; }
	}

	public class CreateAmiImage
	{
		public string ImageName { get; set; }
		public string ImageDescription { get; set; }
		public IEnumerable<AmiImageTag> Tags { get; set; }
	}

	public class LaunchEc2ScheduledInstancesParameters : AmazonActionParameters
	{
		public string ScheduledInstanceIdentificationMethod { get; set; }
		public IEnumerable<string> ScheduledInstanceIds { get; set; }

		public string AmiImageId { get; set; }
		public string VpcSubnetId { get; set; }
		public IEnumerable<string> SecurityGroups { get; set; }
		public string KeyPair { get; set; }
		public string IamInstanceProfileName { get; set; }

		public string UserData { get; set; }
		public string UserDataFormat { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public int? MaxInstanceCount { get; set; }

		public int? TerminateTimeInSeconds { get; set; }
	}

	public class ApplicationNameComparison
	{
		public string ApplicationName { get; set; }
		public string CompareType { get; set; }
	}

	public class ApplicationVersionLabelComparison
	{
		public string ApplicationVersionLabel { get; set; }
		public string CompareType { get; set; }
	}

	public class DeleteElasticBeanstalkApplicationVersionsParameters : AmazonActionParameters
	{
		public string ApplicationIdentificationMethod { get; set; }
		public ApplicationNameComparison ApplicationNameComparison { get; set; }

		public string VersionIdentificationMethod { get; set; }
		public ApplicationVersionLabelComparison ApplicationVersionLabelComparison { get; set; }

		public int MinimumToKeepAll { get; set; }
		public int MinimumToKeepPerApplication { get; set; }

		public int? OlderThanDays { get; set; }

		public bool IsDeleteSourceBundles { get; set; }

		public bool IsTest { get; set; }
	}

	public class ChangeEbsVolumeSize
	{
		public string SizeType { get; set; }
		public int SizeValue { get; set; }
	};

	public class ChangeEbsVolumeType
	{
		public string VolumeType { get; set; }
		public int? Iops { get; set; }
	};

	public class ChangeEbsVolumeEncryption
	{
		public bool IsEncrypt { get; set; }
		public string KmsKeyId { get; set; }
	};

	public class ChangeDeleteOnTerminate
	{
		public string DeleteOnTerminate { get; set; }
	}

	public class AmazonChangeEbsVolumesParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }

		public IEnumerable<string> VolumeIds { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DeviceName { get; set; }

		public string ConsistencyMethod { get; set; }

		public ChangeEbsVolumeSize Size { get; set; }
		public ChangeEbsVolumeType VolumeType { get; set; }
		public ChangeEbsVolumeEncryption Encryption { get; set; }
		public ChangeDeleteOnTerminate DeleteOnTerminate { get; set; }

		public bool IsDeleteOldVolumes { get; set; }
		public bool IsDeleteSnapshots { get; set; }
	}

	public class CloudWatchNamespaceComparison
	{
		public string CompareType { get; set; }
		public string Namespace { get; set; }
	}

	public class DeleteUnusedCloudWatchAlarmsParameters : AmazonActionParameters
	{
		public string AlarmIdentificationMethod { get; set; }
		public CloudWatchNamespaceComparison NamespaceComparison { get; set; }

		public string DeleteCriteria { get; set; }

		public bool IsTest { get; set; }
	}

	public class LoadBalancerNameComparison
	{
		public string LoadBalancerName { get; set; }
		public string CompareType { get; set; }
	}

	public class DaysUnused
	{
		public int NumDays { get; set; }
		public string ResourceTagName { get; set; }
	}

	public class DeleteUnusedElasticLoadBalancersParameters : AmazonActionParameters
	{
		public string LoadBalancerIdentificationMethod { get; set; }
		public LoadBalancerNameComparison LoadBalancerNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public DaysUnused DaysUnused { get; set; }
	}

	public class GroupNameComparison
	{
		public string GroupName { get; set; }
		public string CompareType { get; set; }
	}

	public class UpdateAutoScalingGroupsParameters : AmazonActionParameters
	{
		public string GroupIdentificationMethod { get; set; }
		public GroupNameComparison GroupNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string LaunchConfigurationName { get; set; }
		public int? MinSize { get; set; }
		public int? MaxSize { get; set; }
		public int? DesiredSize { get; set; }

		public int? RestoreTimeInSeconds { get; set; }
	}

	public class BucketNameComparison
	{
		public string BucketName { get; set; }
		public string CompareType { get; set; }
	}

	public class AmazonApplyS3BucketPolicyParameters : AmazonActionParameters
	{
		public string BucketIdentificationMethod { get; set; }
		public BucketNameComparison BucketNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string PolicyType { get; set; }
		public string CustomPolicy { get; set; }

		public string ApplyMethod { get; set; }

		public bool IsTest { get; set; }
	}

	public class TagEbsVolumesParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public IEnumerable<string> VolumeIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string CopyInstanceTagsMethod { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
		public string SetTagsMethod { get; set; }
		public bool IsTest { get; set; }
	}

	public class Ec2InstancesReportParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
	}

	public class RebootWorkSpacesWorkspacesParameters : AmazonActionParameters
	{
		public string WorkspaceIdentificationMethod { get; set; }
		public IEnumerable<string> WorkspaceIds { get; set; }
		public IEnumerable<string> UserNames { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
	}

	public class RebuildWorkSpacesWorkspacesParameters : AmazonActionParameters
	{
		public string WorkspaceIdentificationMethod { get; set; }
		public IEnumerable<string> WorkspaceIds { get; set; }
		public IEnumerable<string> UserNames { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
	}

	public class DescriptionComparison
	{
		public string Description { get; set; }
		public string CompareType { get; set; }
	}

	public class AmazonTagEbsSnapshotsParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }
		public IEnumerable<string> SnapshotIds { get; set; }
		public IEnumerable<string> VolumeIds { get; set; }
		public DescriptionComparison DescriptionComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string CopyVolumeTagsMethod { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
		public string SetTagsMethod { get; set; }
		public bool IsTest { get; set; }
	}

	public class AmazonChangeEc2InstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DeregisterFromLoadBalancers { get; set; }

		public string InstanceType { get; set; }
		public bool? IsEbsOptimized { get; set; }
		public bool? IsEnableTerminationProtection { get; set; }

		public int? RevertTimeInSeconds { get; set; }
	}

	public class StopWorkSpacesWorkspacesParameters : AmazonActionParameters
	{
		public string WorkspaceIdentificationMethod { get; set; }
		public IEnumerable<string> WorkspaceIds { get; set; }
		public IEnumerable<string> UserNames { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
	}

	public class AmazonCreateCloudTrailTrailsParameters : AmazonActionParameters
	{
		public string TrailName { get; set; }
		public string CreationRule { get; set; }
		public string RegionsToApply { get; set; }
		public string MultiRegionLocation { get; set; }
		public string GlobalServiceEventsLocation { get; set; }

		public string BucketName { get; set; }
		public string Prefix { get; set; }
		public string KmsKeyId { get; set; }
		public bool IsEnableLogFileValidation { get; set; }

		public string SnsTopicName { get; set; }
		
		public IEnumerable<Tag> Tags { get; set; }
	}

	public class StartWorkSpacesWorkspacesParameters : AmazonActionParameters
	{
		public string WorkspaceIdentificationMethod { get; set; }
		public IEnumerable<string> WorkspaceIds { get; set; }
		public IEnumerable<string> UserNames { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int? StopTimeInSeconds { get; set; }
	}

	public class DeleteUnusedWorkSpacesWorkspacesParameters : AmazonActionParameters
	{
		public string WorkspaceIdentificationMethod { get; set; }
		public IEnumerable<string> WorkspaceIds { get; set; }
		public IEnumerable<string> UserNames { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int ReportTimeInDays { get; set; }
		public string ReportFormat { get; set; }
		public int DeleteTimeInDays { get; set; }
		public string CheckType { get; set; }
		public string CloudWatchGapsAllowed { get; set; }

		public bool IsTest { get; set; }
	}

	public class AmazonCreateLightsailInstanceSnapshotsParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public LightsailInstanceNameComparison InstanceNameComparison { get; set; }

		public string SnapshotName { get; set; }

		public string ConsistencyMethod { get; set; }
	}

	public class DeleteLightsailInstanceSnapshotsParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public SnapshotNameComparison SnapshotNameComparison { get; set; }

		public string DeleteScheme { get; set; }

		public FirstInFirstOutDeleteSchemeParameters FirstInFirstOutParameters { get; set; }
		public GrandfatherFatherSonDeleteSchemeParameters GrandfatherFatherSonParameters { get; set; }

		public string GroupingMethod { get; set; }

		public bool IsTest { get; set; }
	}

	public class LightsailInstanceNameComparison
	{
		public string InstanceName { get; set; }
		public string CompareType { get; set; }
	}

	public class LightsailInstanceSnapshotNameComparison
	{
		public string CompareType { get; set; }
		public string SnapshotName { get; set; }
	}

	public class CreateLightsailInstancesInstance
	{
		public string InstanceName { get; set; }
		public string StaticIpName { get; set; }
	}

	public class AmazonCreateLightsailInstancesFromSnapshotsParameters : AmazonActionParameters
	{
		public IEnumerable<CreateLightsailInstancesInstance> Instances { get; set; }
		public string DuplicateInstanceResolutionMethod { get; set; }

		public string SnapshotIdentificationMethod { get; set; }
		public LightsailInstanceNameComparison InstanceNameComparison { get; set; }
		public LightsailInstanceSnapshotNameComparison SnapshotNameComparison { get; set; }

		public string AvailabilityZone { get; set; }
		public string BundleId { get; set; }
		public string KeyPairName { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
		public string FinalSnapshotName { get; set; }
	}

	public class AmazonAttachIamRoleToEc2InstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string IamRoleName { get; set; }
	}

	public class RunAthenaQueryParameters : AmazonActionParameters
	{
		public string QueryType { get; set; }
		public string QueryName { get; set; }
		public string QueryString { get; set; }
		public string Database { get; set; }

		public string OutputBucketName { get; set; }
		public string OutputPrefix { get; set; }
		public string OutputEncryptionMethod { get; set; }
		public string OutputKmsKeyId { get; set; }

		public string TargetType { get; set; }
		public IEnumerable<string> TargetEmails { get; set; }
		public string ReportFormat { get; set; }
	}

	public class StartRdsInstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int? StopTimeInSeconds { get; set; }
		public string SnapshotId { get; set; }
	}

	public class StopRdsInstancesParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string SnapshotId { get; set; }

		public string ChangeMultiAz { get; set; }
		public string DeleteReplicas { get; set; }

		public int? RestartTimeInSeconds { get; set; }
		public string RestartTimeFrame { get; set; }
	}

	public class LoadBalancerRegistration
	{
		public string IdentificationMethod { get; set; }
		public IEnumerable<string> LoadBalancerNames { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
		public string ResourceTagName { get; set; }
	}

	public class TargetGroupRegistration
	{
		public string IdentificationMethod { get; set; }
		public IEnumerable<string> TargetGroupNames { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
		public string ResourceTagName { get; set; }

		public IEnumerable<int> Ports { get; set; }
	}

	public class RegisterEc2InstancesWithLoadBalancersParameters : AmazonActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public LoadBalancerRegistration LoadBalancers { get; set; }
		public TargetGroupRegistration TargetGroups { get; set; }

		public int? DeregisterTimeInSeconds { get; set; }
	}

	public class EbsVolumeSnapshotReportParameters : AmazonActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public IEnumerable<string> VolumeIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int NumSnapshotsWarning { get; set; }
		public int NumDaysWarning { get; set; }
		public int NumSnapshotsAlert { get; set; }
		public int NumDaysAlert { get; set; }

		public string TargetType { get; set; }
		public IEnumerable<string> TargetEmails { get; set; }
		public string ReportFormat { get; set; }
	}

	public class RdsClusterIdComparison
	{
		public string CompareType { get; set; }
		public string ClusterId { get; set; }
	}

	public class RestoreRdsClusterParameters : AmazonActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }

		public RdsSnapshotIdComparison SnapshotIdComparison { get; set; }
		public RdsClusterIdComparison ClusterIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DuplicateClusterResolutionMethod { get; set; }

		public string NewClusterId { get; set; }

		public IEnumerable<string> SecurityGroups { get; set; }
		public string ClusterSubnetGroupName { get; set; }
		public string OptionGroupName { get; set; }
		public string ClusterParameterGroupName { get; set; }
		public string ChangeBackupRetentionPeriod { get; set; }
		public int? NewBackupRetentionDays { get; set; }

		public IEnumerable<Tag> Tags { get; set; }

		public string NewInstanceId { get; set; }
		public string DbInstanceClass { get; set; }
		public string ChangePubliclyAccessible { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
		public string FinalSnapshotId { get; set; }
	}

	public class AmazonExportDynamoDbTablesParameters : AmazonActionParameters
	{
		public string TableIdentificationMethod { get; set; }
		public TableNameComparison TableNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int ReadThroughputPercent { get; set; }

		public string BucketName { get; set; }
		public string Prefix { get; set; }
		public string TargetCredentialId { get; set; }
		public string OutputFormat { get; set; }
	}

	public class AmazonCreateDynamoDbBackupsParameters : AmazonActionParameters
	{
		public string TableIdentificationMethod { get; set; }
		public TableNameComparison TableNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string BackupName { get; set; }
	}

	public class BackupNameComparison
	{
		public string BackupName { get; set; }
		public string CompareType { get; set; }
	}

	public class DeleteDynamoDbBackupsParameters : AmazonActionParameters
	{
		public string BackupIdentificationMethod { get; set; }
		public BackupNameComparison BackupNameComparison { get; set; }
		public IEnumerable<string> TableNames { get; set; }
		public TableNameComparison TableNameComparison { get; set; }
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

	public class AppStreamFleetNameComparison
	{
		public string FleetName { get; set; }
		public string CompareType { get; set; }
	}

	public class StartAppStreamFleetsParameters : AmazonActionParameters
	{
		public string FleetIdentificationMethod { get; set; }
		public AppStreamFleetNameComparison FleetNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public int? StopTimeInSeconds { get; set; }
	}

	public class EcsClusterNameComparison
	{
		public string CompareType { get; set; }
		public string ClusterName { get; set; }
	}

	public class EcsServiceNameComparison
	{
		public string CompareType { get; set; }
		public string ServiceName { get; set; }
	}

	public class AmazonUpdateEcsServicesParameters : AmazonActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public EcsClusterNameComparison ClusterNameComparison { get; set; }

		public string ServiceIdentificationMethod { get; set; }
		public EcsServiceNameComparison ServiceNameComparison { get; set; }

		public int? DesiredCount { get; set; }

		public int? RevertTimeInSeconds { get; set; }
	}
}
