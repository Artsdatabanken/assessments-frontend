﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Assessments.Shared.Helpers
{
    public static class Extensions
    {
        public static string DisplayName(this MemberInfo property)
        {
            var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
           
            return attribute.DisplayName;
        }

        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            
            if (attributes.Length > 0)	
                return (T) attributes[0];

            return null;
        }

        public static string Description(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string DisplayName(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }

        public static IEnumerable<T> ToEnumerable<T>(this IEnumerable<string> array)
        {
            return array.Where(c => Enum.IsDefined(typeof(T), c)).Select(a => (T) Enum.Parse(typeof(T), a));
        }
    }
}