namespace MCDTP.IO.MemoryMappedFile

  open MCDTP.IO.MemoryMappedFile.Partition

  [<AutoOpen>]
  module Expression =

    type MMFBuilder() =

      member __.Return() = MMFConfiguration.Instance

    type MMFBuilder with

      [<CustomOperation ("usePartitionConfig", MaintainsVariableSpaceUsingBind = true)>]
      member __.UsePartitionConfig(m,p:PartitionConfiguration) =
        MMFConfiguration.set MMFConfiguration.partitionConfig_ p m

      [<CustomOperation ("handleFile", MaintainsVariableSpaceUsingBind = true)>]
      member __.HandleFile(m,f) =
        MMFConfiguration.set MMFConfiguration.fileName_ m f

      [<CustomOperation ("isReadOnly", MaintainsVariableSpaceUsingBind = true)>]
      member __.IsReadOnly(m) = MMFConfiguration.set MMFConfiguration.readOrWrite_ true m

      [<CustomOperation ("isWriteOnly", MaintainsVariableSpaceUsingBind = true)>]
      member __.IsWriteOnly(m) = MMFConfiguration.set MMFConfiguration.readOrWrite_ false m

    let mmf = MMFBuilder()