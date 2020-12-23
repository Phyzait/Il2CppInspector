﻿/*
    Copyright 2020 Katy Coe - http://www.djkaty.com - https://github.com/djkaty

    All rights reserved.
*/

using System;
using System.IO;
using NoisyCowStudios.Bin2Object;
using Il2CppInspector.Reflection;

// Hooks we provide to plugins which can choose whether or not to provide implementations
namespace Il2CppInspector.PluginAPI.V100
{
    /// <summary>
    /// Executes when the plugin's options are updated by the user
    /// Not called on first load (with the default, possibly incomplete options provided by the plugin author)
    /// Do not perform any long-running operations here
    /// Implementation is optional - the default is to do nothing
    /// </summary>
    public partial interface IPlugin
    {
        void OptionsChanged(PluginOptionsChangedEventInfo e) { }
    }

    /// <summary>
    /// Process global-metadata.dat when it is first opened as a sequence of bytes
    /// Seek cursor will be at the start of the file
    /// </summary>
    public interface IPreProcessMetadata
    {
        void PreProcessMetadata(BinaryObjectStream stream, PluginPreProcessMetadataEventInfo data);
    }

    /// <summary>
    /// Process global-metadata.dat after it has been loaded into a Metadata object
    /// </summary>
    public interface IPostProcessMetadata
    {
        void PostProcessMetadata(Metadata metadata, PluginPostProcessMetadataEventInfo data);
    }

    /// <summary>
    /// Fetch all of the .NET identifier strings
    /// </summary>
    public interface IGetStrings
    {
        void GetStrings(Metadata metadata, PluginGetStringsEventInfo data);
    }

    /// <summary>
    /// Fetch all of the (constant) string literals
    /// </summary>
    public interface IGetStringLiterals
    {
        void GetStringLiterals(Metadata metadata, PluginGetStringLiteralsEventInfo data);
    }

    /// <summary>
    /// Post-process the entire IL2CPP application package after the metadata and binary have been loaded and merged
    /// </summary>
    public interface IPostProcessPackage
    {
        void PostProcessPackage(Il2CppInspector package, PluginPostProcessPackageEventInfo data);
    }

    /// <summary>
    /// Post-process the .NET type model to make changes after it has been fully created
    /// </summary>
    public interface IPostProcessTypeModel
    {
        void PostProcessTypeModel(TypeModel model, PluginPostProcessTypeModelEventInfo data);
    }
}
