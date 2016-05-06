using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeddly.Model
{
	public class Tag
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}

	public class AmazonAddSecurityGroupRuleParameters : ActionParameters
	{
		public string Direction { get; set; }
		public string Protocol { get; set; }
		public int FromPort { get; set; }
		public int ToPort { get; set; }

		public string SecurityGroup { get; set; }
		public string Source { get; set; }

		public int? RevokeTimeInSeconds { get; set; }
	}

	public class AmazonAssociateElasticIpParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string PublicIp { get; set; }
	}

	public class AmazonBackupRoute53HostedZoneParameters : ActionParameters
	{
		public string HostedZoneName { get; set; }
		public string BucketName { get; set; }
		public string ObjectKey { get; set; }
		public string ExportFormat { get; set; }
	}

	public class AmazonBackupEc2InstanceParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string SnapshotName { get; set; }
		public string Description { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public List<Tag> Tags { get; set; }
		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmazonBackupEc2InstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }

		public List<string> InstanceIds { get; set; }

		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public string RollingInstanceStopsMethod { get; set; }
		public string RollingInstanceStopsResourceTagName { get; set; }
		public double RollingInstanceStopsDelaySeconds { get; set; }
		public bool RollingInstanceStopsIsWaitForStatus { get; set; }

		public string SnapshotName { get; set; }
		public string Description { get; set; }

		public List<Tag> Tags { get; set; }
		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmazonBackupRoute53HostedZonesParameters : ActionParameters
	{
		public string HostedZoneIdentificationMethod { get; set; }

		public List<string> HostedZoneNames { get; set; }

		public string BucketName { get; set; }
		public string ObjectKey { get; set; }
		public string ExportFormat { get; set; }
	}

	public class AmazonBackupMySQLServerParameters : ActionParameters
	{
		public string EngineVersion { get; set; }

		public string AvailabilityZone { get; set; }
		public string InstanceType { get; set; }
		public string SecurityGroup { get; set; }
		public string SubnetId { get; set; }
		public string PrivateIpAddress { get; set; }
		public int? VolumeSize { get; set; }

		public bool IsUseSpot { get; set; }
		public double? MaxSpotPrice { get; set; }

		public string Endpoint { get; set; }
		public int Port { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public IEnumerable<string> Databases { get; set; }
		public bool IsSeparateDatabases { get; set; }
		public bool IsOmitDatabasesFlag { get; set; }

		public string ExtraCommandLineArguments { get; set; }

		public string TargetType { get; set; }
		public string BucketName { get; set; }
		public string ObjectKey { get; set; }
		public string EncryptionType { get; set; }
	}

	public class AmazonChangeEc2InstanceTypeParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string DeregisterFromLoadBalancers { get; set; }

		public string InstanceType { get; set; }
		public bool? IsEbsOptimized { get; set; }

		public int? RevertTimeInSeconds { get; set; }

	}

	public class AmazonChangeRdsInstanceClassParameters : ActionParameters
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

	public class AmazonCopyAmiImagesParameters : ActionParameters
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

		public List<Tag> Tags { get; set; }

		public bool IsCopyImagePermissions { get; set; }
		public bool IsCopySnapshotPermissions { get; set; }
	}

	public class AmazonCopyAmiToRegionParameters : ActionParameters
	{
	}

	public class AmazonCopyEbsSnapshotsParameters : ActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }

		public string SnapshotId { get; set; }
		public string VolumeId { get; set; }

		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }

		public int? NewerThanDays { get; set; }

		public bool IsCopyTags { get; set; }

		public bool IsPreventDuplicates { get; set; }

		public List<Tag> Tags { get; set; }
	}

	public class AmazonCopyEbsVolumeParameters : ActionParameters
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

	public class AmazonCopyEc2InstanceParameters : ActionParameters
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

	public class AmazonCopyRdsSnapshotsParameters : ActionParameters
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
		public List<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmazonCopyS3ObjectsParameters : ActionParameters
	{
		public string SourceBucketName { get; set; }
		public string SourcePrefix { get; set; }

		public string TargetBucketName { get; set; }
		public string RenameMethod { get; set; }
		public string TargetPrefix { get; set; }
		public string StorageClass { get; set; }

		public string OverwriteRule { get; set; }
	}

	public class CreateAmiImagesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }

		public IEnumerable<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }
		public string ImageName { get; set; }

		public bool IsNoReboot { get; set; }

		public string SetImageNameTagMethod { get; set; }
		public string CustomImageNameTag { get; set; }

		public string SetSnapshotNameTagMethod { get; set; }
		public string CustomSnapshotNameTag { get; set; }

		public IEnumerable<AmiImageTag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class AmiImageTag
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public bool AddToImage { get; set; }
		public bool AddToSnapshots { get; set; }
	}

	public class CreateDirectoryServiceSnapshotsParameters : ActionParameters
	{
		public string DirectoryIdentificationMethod { get; set; }
		public List<string> DirectoryId { get; set; }
		public List<string> DirectoryNames { get; set; }

		public string SnapshotName { get; set; }
	}

	public class CreateEbsSnapshotsParameters : ActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public List<string> VolumeIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }
		public string SnapshotName { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public List<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class CreateElastiCacheClusterParameters : ActionParameters
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

	public class CreateElastiCacheReadReplicaParameters : ActionParameters
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


	public class CreateElastiCacheSnapshotsParameters : ActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public ElastiCacheClusterIdComparison ClusterIdComparison { get; set; }

		public string SnapshotId { get; set; }
	}

	public class CreateImageParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string Description { get; set; }
		public string ImageName { get; set; }
		public bool IsNoReboot { get; set; }

		public string SetImageNameTagMethod { get; set; }
		public string CustomImageNameTag { get; set; }
		public string SetSnapshotNameTagMethod { get; set; }
		public string CustomSnapshotNameTag { get; set; }

		public IEnumerable<AmiImageTag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class CreateRdsReadReplicaParameters : ActionParameters
	{
		public string DbInstanceId { get; set; }
		public string ReplicaId { get; set; }
		public string AvailabilityZone { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
		public string FinalSnapshotId { get; set; }
	}

	public class CreateRdsSnapshotParameters : ActionParameters
	{
		public string DbInstanceId { get; set; }
		public string SnapshotId { get; set; }

		public List<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class CreateRdsSnapshotsParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string SnapshotId { get; set; }

		public List<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
		public string TargetCredentialId { get; set; }
	}

	public class CreateRedshiftSnapshotParameters : ActionParameters
	{
		public string ClusterId { get; set; }
		public string SnapshotId { get; set; }

		public List<Tag> Tags { get; set; }
	}

	public class CreateEbsSnapshotParameters : ActionParameters
	{
		public string VolumeId { get; set; }

		public string Description { get; set; }
		public string SnapshotName { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public List<Tag> Tags { get; set; }

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

	public class DeleteDirectoryServiceSnapshotsParameters : ActionParameters
	{
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }

		public bool IsPerDirectory { get; set; }

		public DeleteDirectoryServiceSnapshotsComparison DeleteComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteDynamoDbItemsParameters : ActionParameters
	{
		public string TableName { get; set; }
		public string DateAttribute { get; set; }
		public int OlderThanDays { get; set; }
		public string DateType { get; set; }
		public int ScanLimit { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteElastiCacheClustersParameters : ActionParameters
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

	public class DeleteElastiCacheSnapshotsParameters : ActionParameters
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

	public class DeleteRdsInstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }

		public string FinalSnapshotId { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteRdsSnapshotsComparison
	{
		public string Field { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
		public string ResourceTagName { get; set; }
	}

	public class DeleteRdsSnapshotsParameters : ActionParameters
	{
		public DeleteRdsSnapshotsComparison DeleteComparison { get; set; }
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }

		public bool IsIncludeClusterSnapshots { get; set; }

		public bool IsTest { get; set; }
	}

	public class RedshiftClusterIdComparison
	{
		public string CompareType { get; set; }
		public string ClusterId { get; set; }
	}

	public class DeleteRedshiftClustersParameters : ActionParameters
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

	public class DeleteRedshiftSnapshotsParameters : ActionParameters
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

	public class DeleteS3ObjectsParameters : ActionParameters
	{
		public string BucketName { get; set; }
		public string Prefix { get; set; }
		public int? OlderThanDays { get; set; }

		public DeleteS3ObjectsComparison DeleteComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeleteSnapshotsComparison
	{
		public string Field { get; set; }
		public string ResourceTagName { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
	}

	public class DeleteSnapshotsParameters : ActionParameters
	{
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }

		public bool IsPerVolume { get; set; }

		public DeleteSnapshotsComparison DeleteComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeregisterImagesComparison
	{
		public string Field { get; set; }
		public string ResourceTagName { get; set; }
		public string CompareType { get; set; }
		public string Value { get; set; }
	}

	public class DeregisterImagesParameters : ActionParameters
	{
		public int? OlderThanDays { get; set; }
		public int? MinimumToKeep { get; set; }

		public DeregisterImagesComparison DeleteComparison { get; set; }

		public bool IsDeleteSnapshots { get; set; }
		public bool IsDeleteFromS3 { get; set; }

		public bool IsTest { get; set; }
	}

	public class DeregisterInstanceFromLoadBalancerParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }

		public string DeregisterMethod { get; set; }
		public string LoadBalancerName { get; set; }
	}

	public class ExportEc2InstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public List<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string ConsistencyMethod { get; set; }
		public string DeregisterFromLoadBalancers { get; set; }

		public string BucketName { get; set; }
		public string Prefix { get; set; }

		public string TargetEnvironment { get; set; }
		public string DiskImageFormat { get; set; }
	}

	public class GenerateIamCredentialReportParameters : ActionParameters
	{
	}

	public class GrowEbsVolumeParameters : ActionParameters
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

	public class InvokeLambdaFunctionParameters : ActionParameters
	{
		public string FunctionName { get; set; }
		public string Arguments { get; set; }
	}

	public class LaunchInstanceParameters : ActionParameters
	{
		public string ImageIdentificationMethod { get; set; }
		public string AmiImageId { get; set; }

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

		public int? TerminateTimeInSeconds { get; set; }
	}

	public class ModifyS3ObjectsParameters : ActionParameters
	{
		public string BucketName { get; set; }
		public string Prefix { get; set; }
		public string ServerSideEncryptionType { get; set; }
		public string StorageClass { get; set; }
	}

	public class PublishSnsMessageParameters : ActionParameters
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

	public class RebootElastiCacheClustersParameters : ActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public ElastiCacheClusterIdComparison ClusterIdComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class RebootInstanceParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
	}

	public class RebootRdsInstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public RdsInstanceIdComparison InstanceIdComparison { get; set; }

		public bool IsForceFailover { get; set; }
	}

	public class RegisterInstanceWithLoadBalancerParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }

		public string LoadBalancerName { get; set; }

		public int? DeregisterTimeInSeconds { get; set; }
	}

	public class RequestSpotInstanceParameters : ActionParameters
	{
		public string ImageIdentificationMethod { get; set; }
		public string AmiImageId { get; set; }

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

	public class ResizeRedshiftClusterParameters : ActionParameters
	{
		public string ClusterIdentificationMethod { get; set; }
		public string ClusterId { get; set; }

		public string NodeType { get; set; }
		public int? NumNodes { get; set; }

		public int? RevertTimeInSeconds { get; set; }
	}

	public class ResourceReportParameters : ActionParameters
	{
		public bool IsIncludeEc2 { get; set; }
		public bool IsIncludeRds { get; set; }
		public bool IsIncludeRoute53 { get; set; }
		public bool IsIncludeS3 { get; set; }
		public bool IsIncludeElb { get; set; }
	}

	public class RestoreRdsInstanceParameters : ActionParameters
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

	public class RestoreRedshiftClusterParameters : ActionParameters
	{
		public string SnapshotIdentificationMethod { get; set; }
		public string SnapshotId { get; set; }
		public string ClusterId { get; set; }

		public string NewClusterId { get; set; }
		public string AvailabilityZone { get; set; }

		public string ClusterSubnetGroupName { get; set; }
		public string SecurityGroup { get; set; }
		public string ClusterParameterGroupName { get; set; }

		public int? DeleteTimeInSeconds { get; set; }
		public string FinalSnapshotId { get; set; }
	}

	public class RunningTimeReportParameters : ActionParameters
	{
		public string InstanceIdentificationMethods { get; set; }
		public List<string> InstanceIds { get; set; }

		public int MinimumMinutesForBreak { get; set; }

		public string TimePeriod { get; set; }
		public int? TimePeriodDays { get; set; }
	}

	public class StartInstanceParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public string ElasticIp { get; set; }
		public string LoadBalancerName { get; set; }

		public bool IsCheckReachability { get; set; }
		public bool IsSendEmailOnReachabilityFailure { get; set; }

		public int? StopTimeInSeconds { get; set; }
	}

	public class StartMultipleInstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public List<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string ElasticIp { get; set; }
		public string LoadBalancerName { get; set; }

		public bool IsCheckReachability { get; set; }
		public bool IsSendEmailOnReachabilityFailure { get; set; }

		public int? StopTimeInSeconds { get; set; }
	}

	public class StartSwfWorkflowExecutionParameters : ActionParameters
	{
		public string Domain { get; set; }
		public string WorkflowTypeName { get; set; }
		public string WorkflowTypeVersion { get; set; }
		public string WorkflowExecutionId { get; set; }
		public string Input { get; set; }
		public string TaskListName { get; set; }

		public List<string> WorkflowTags { get; set; }
	}

	public class StopInstanceParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }

		public bool IsForceStop { get; set; }
	}

	public class StopMultipleInstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public List<string> InstanceIds { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public bool IsForceStop { get; set; }
	}

	public class TerminateInstanceParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
		public string InstanceName { get; set; }
	}

	public class UpdateAutoScalingGroupParameters : ActionParameters
	{
		public string GroupName { get; set; }
		public string LaunchConfigurationName { get; set; }

		public int? MinSize { get; set; }
		public int? MaxSize { get; set; }
		public int? DesiredSize { get; set; }

		public int? RestoreTimeInSeconds { get; set; }
	}

	public class UpdateRoute53RecordParameters : ActionParameters
	{
		public string HostedZoneName { get; set; }
		public string RecordName { get; set; }
		public string RecordType { get; set; }

		public string InstanceIdentificationMethod { get; set; }
		public string InstanceId { get; set; }
	}

	public class CreateCloudFormationStackParameters : ActionParameters
	{
		public string StackName { get; set; }
		public string TemplateFormat { get; set; }
		public string TemplateBody { get; set; }
		public string TemplateUrl { get; set; }
		public string TemplateBucketName { get; set; }
		public string TemplateObjectKey { get; set; }
		
		public List<CloudFormationParameter> Parameters { get; set; }
		public List<string> Capabilities { get; set; }
		public List<Tag> Tags { get; set; }

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

	public class DeleteCloudFormationStacksParameters : ActionParameters
	{
		public string StackIdentificationMethod { get; set; }
		public StackNameComparison StackNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public bool IsTest { get; set; }
	}

	public class StackNameComparison
	{
		public string StackName { get; set; }
		public string CompareType { get; set; }
	}

	public class ChangeDynamoDbTablesParameters : ActionParameters
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

	public class CreateStorageGatewaySnapshotsParameters : ActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public GatewayNameComparison GatewayNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string Description { get; set; }
		public string SnapshotName { get; set; }
		public List<Tag> Tags { get; set; }

		public string TargetRegionName { get; set; }
	}

	public class GatewayNameComparison
	{
		public string GatewayName { get; set; }
		public string CompareType { get; set; }
	}

	public class EraseDeletedS3ObjectsParameters : ActionParameters
	{
		public string BucketName { get; set; }
		public string Prefix { get; set; }

		public bool IsTest { get; set; }
	}

	public class SendSsmCommandParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }

		public List<string> InstanceIds { get; set; }

		public InstanceNameComparison InstanceNameComparison { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public string DocumentName { get; set; }

		public IEnumerable<SsmCommandParameter> CommandParameters { get; set; }

		public int? TimeoutInSeconds { get; set; }
	}

	public class SsmCommandParameter
	{
		public string ParameterName { get; set; }
		public IEnumerable<string> Values { get; set; }
	}

	public class DeleteEbsVolumesParameters : ActionParameters
	{
		public string VolumeIdentificationMethod { get; set; }
		public IEnumerable<string> VolumeIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }

		public DaysDetached DaysDetached { get; set; }
		public CreateEbsSnapshot CreateEbsSnapshot { get; set; }
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

	public class RebootEc2InstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }
	}

	public class TerminateEc2InstancesParameters : ActionParameters
	{
		public string InstanceIdentificationMethod { get; set; }
		public IEnumerable<string> InstanceIds { get; set; }
		public ResourceTagComparison ResourceTagComparison { get; set; }
		public InstanceNameComparison InstanceNameComparison { get; set; }

		public int? OlderThanDays { get; set; }

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

	public class LaunchEc2ScheduledInstancesParameters : ActionParameters
	{
		public string ScheduledInstanceIdentificationMethod { get; set; }
		public IEnumerable<string> ScheduledInstanceIds { get; set; }

		public string AmiImageId { get; set; }
		public string VpcSubnetId { get; set; }
		public IEnumerable<string> SecurityGroups { get; set; }
		public string KeyPair { get; set; }
		public string IamInstanceProfile { get; set; }

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

	public class DeleteElasticBeanstalkApplicationVersionsParameters : ActionParameters
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
		public int SizeValue { get; set; }
		public string SizeType { get; set; }
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

	public class ChangeEbsVolumesParameters : ActionParameters
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
		public string DeleteOnTerminate { get; set; }

		public bool IsDeleteOldVolumes { get; set; }
		public bool IsDeleteSnapshots { get; set; }
	}
}
