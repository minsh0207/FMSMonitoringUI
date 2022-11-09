﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnifiedAutomation.UaBase;

namespace OPCUAClientClassLib
{
    [Serializable]
    public class EqpTagItem
    {
        public EqpTagItem()
        {
            //
        }

        private EnumTagType ConvertFromString(string tag_type)
        {
            string to_convert = tag_type.Trim().ToUpper();
            return (EnumTagType)System.Enum.Parse(typeof(EnumTagType), to_convert);
        }

        public EqpTagItem(string tag_name, EnumTagType tag_type, string default_Value, EqpTagItem parent, bool subscribe, bool batchreport)
        {
            TagName = tag_name;
            TagType = tag_type;
            DefaultValue = default_Value;
            Subscribe = subscribe;
            BatchReport = batchreport;
            Parent = parent;
            Level = parent == null ? 0 : parent.Level + 1;
            Children = new List<EqpTagItem>();
        }

        public EqpTagItem(string tag_name, string tag_type, string default_Value, EqpTagItem parent, bool subscribe, bool batchreport)
        {
            TagName = tag_name;
            TagType = ConvertFromString(tag_type);
            DefaultValue = default_Value;
            Subscribe = subscribe;
            BatchReport = batchreport;
            Parent = parent;
            Level = parent == null ? 0 : parent.Level + 1;
            Children = new List<EqpTagItem>();
        }

        public void AddChild(string tag_name, EnumTagType tag_type, string default_Value, List<EqpTagItem> children, bool subscribe, bool batchreport)
        {
            Children.Add(new EqpTagItem()
            {
                TagName = tag_name,
                TagType = tag_type,
                DefaultValue = default_Value,
                Subscribe = subscribe,
                BatchReport = batchreport,
                Parent = this,
                Level = this.Level + 1,
                Children = children ?? new List<EqpTagItem>()
            });
        }

        public void AddChild(string tag_name, string tag_type, string default_Value, List<EqpTagItem> children, bool subscribe, bool batchreport)
        {
            Children.Add(new EqpTagItem()
            {
                TagName = tag_name,
                TagType = ConvertFromString(tag_type),
                DefaultValue = default_Value,
                Subscribe = subscribe,
                BatchReport = batchreport,
                Parent = this,
                Level = this.Level + 1,
                Children = children ?? new List<EqpTagItem>()
            });
        }

        public string GetNodePath(char path_sep)
        {
            List<string> paths = new List<string>();
            EqpTagItem walker = this;

            while (walker != null)
            {
                paths.Add(walker.TagName);
                walker = walker.Parent;
            }
            paths.Reverse();
            return String.Join(path_sep.ToString(), paths.ToArray());
        }

        public string TagName { get; set; }

        public EnumTagType TagType { get; set; }

        public string DefaultValue { get; set; }

        public bool Subscribe { get; set; }

        public bool BatchReport { get; set; }

        public EqpTagItem Parent { get; set; }

        public int Level { get; set; }

        public List<EqpTagItem> Children { get; set; }
    }

    [Serializable]
    public class OPCTagItem
    {
        public OPCTagItem()
        {
            //
        }

        public string TagFullName { get; set; }

        public bool Subscribe { get; set; }

        public int ConveyorNo { get; set; }

        public NodeId NodeId { get; set; }

        //public bool BatchReport { get; set; }

        //public EqpTagItem Parent { get; set; }

        //public int Level { get; set; }

        //public List<EqpTagItem> Children { get; set; }
    }

    public static class ListExtensions
    {
        public static void DebugPrint(this List<EqpTagItem> list, int level = 0)
        {
            foreach (var item in list)
            {
                System.Diagnostics.Debug.Write(new string('\t', level));
                System.Diagnostics.Debug.WriteLine($"{item.TagName}, {item.TagType}, {item.Level}");
                item.Children.DebugPrint(item.Level + 1);
            }
        }


        public static EqpTagItem FindInTree(this List<EqpTagItem> list, string tag_name_to_find)
        {
            if (string.IsNullOrEmpty(tag_name_to_find)) return null;

            //
            for(int i = list.Count-1; i>=0; i--)
            {
                if (list[i].TagName == tag_name_to_find) return list[i];
                EqpTagItem tag = FindInTree(list[i].Children, tag_name_to_find);
                if (tag != null) return tag;
            }

            //foreach (var item in list)
            //{
            //    if (item.TagName == tag_name_to_find) return item;
            //    EqpTagItem tag = FindInTree(item.Children, tag_name_to_find);
            //    if (tag != null) return tag;
            //}

            return null;
        }

        public static List<EqpTagItem> FindAllInTree(this List<EqpTagItem> list, string tag_name_to_find)
        {
            List<EqpTagItem> flattened = list.Flatten(d => d.Children).ToList();

            List<EqpTagItem> result  = new List<EqpTagItem>();
            foreach (var item in flattened)
            {
                if(item.TagName == tag_name_to_find)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> f)
        {
            return e.SelectMany(c => f(c).Flatten(f)).Concat(e);
        }




        public static List<EqpTagItem> MakeTreeCopy(this List<EqpTagItem> list, EqpTagItem parent)
        {
            List<EqpTagItem> target = new List<EqpTagItem>();

            foreach (var item in list)
            {
                EqpTagItem dupe = new EqpTagItem();
                dupe.TagName = item.TagName;
                dupe.TagType = item.TagType;
                dupe.Level = item.Level;
                dupe.Parent = parent;
                dupe.Subscribe = item.Subscribe;
                dupe.BatchReport = item.BatchReport;
                dupe.Children = MakeTreeCopy(item.Children, dupe);
                target.Add(dupe);
            }

            return target;
        }

    }
}
