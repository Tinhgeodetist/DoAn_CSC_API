﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CSC_API.Common
{
    public class Utilities
    {
        // hàm copy thay vì dùng New Model
        public class PropertyCopier<TParent, TChild> where TParent : class
                                    where TChild : class
        {
            public static void Copy(TParent parent, TChild child)
            {
                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();

                foreach (var parentProperty in parentProperties)
                {
                    if (parentProperty.Name.ToLower() == "id") continue;
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name &&
                            parentProperty.PropertyType == childProperty.PropertyType &&
                            childProperty.SetMethod != null)
                        {
                            if (parentProperty.GetValue(parent) != null)
                                childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }
            }
        }
    }
}
