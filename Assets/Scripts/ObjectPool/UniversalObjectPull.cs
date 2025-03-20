using System;

namespace ObjectPool
{
    public static class UniversalObjectPull
    {
        private static XRPlayerInspector inspectorInstance;
        
        public static XRPlayerInspector PlayerInspector { get => inspectorInstance == null ? throw new Exception("inspectorInstance is null") : inspectorInstance; }

        public static bool AddXRPlayerInspector(XRPlayerInspector inspector)
        {
            if (inspectorInstance == null)
            {
                inspectorInstance = inspector;
                return true;
            }
            
            return false;
        }
        
        public static void RemoveXRPlayerInspector(XRPlayerInspector inspector)
        {
            inspectorInstance = null;
        }
    }
}
