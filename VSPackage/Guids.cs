// Guids.cs
// MUST match guids.h
using System;

namespace QuillCorporation.VSPackage
{
    static class GuidList
    {
        public const string guidVSPackagePkgString = "f16179d9-a272-4d2c-99e5-24bea770c66e";
        public const string guidVSPackageCmdSetString = "f00fad91-2042-4add-a96e-993efbf8df1c";
        public const string guidToolWindowPersistanceString = "ea5e6bce-4942-4785-ad7c-f8b233a3f546";
        public const string guidVSPackageEditorFactoryString = "871bd841-ab89-4333-ad00-8ec9da20b813";

        public static readonly Guid guidVSPackageCmdSet = new Guid(guidVSPackageCmdSetString);
        public static readonly Guid guidVSPackageEditorFactory = new Guid(guidVSPackageEditorFactoryString);
    };
}