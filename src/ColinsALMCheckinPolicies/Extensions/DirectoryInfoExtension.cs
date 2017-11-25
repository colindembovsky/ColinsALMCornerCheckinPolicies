using System.IO;

namespace ColinsALMCheckinPolicies
{
    public static class DirectoryInfoExtension
    {
        public static bool IsParentOf(this DirectoryInfo parentPath, DirectoryInfo childPath)
        {
            bool isParent = false;
            while (childPath.Parent != null)
            {
                if (childPath.Parent.FullName == parentPath.FullName)
                {
                    isParent = true;
                    break;
                }
                else
                {
                    childPath = childPath.Parent;
                }
            }

            return isParent;
        }
    }
}
