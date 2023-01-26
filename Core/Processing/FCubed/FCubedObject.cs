using Cosmos.System.FileSystem.ISO9660;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TurtleOSKit.Core.Processing.FCubed
{
    //TODO: Utilize FCubedCommentAttribute.
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class FCubedCommentAttribute : Attribute
    {
        public enum CommentForm
        {
            SINGLE_LINE,
            MULTI_LINE
        }

        private CommentForm commentForm = CommentForm.SINGLE_LINE;
        private string commentText = "";

        public FCubedCommentAttribute(string comment, CommentForm form = CommentForm.SINGLE_LINE)
        {
            commentText = comment;
            commentForm = form;
        }

        public string GetCommentText() => commentText.Trim();
        public CommentForm GetCommentForm() => commentForm;

        public override string ToString()
        {
            string s = "";
            if (GetCommentForm() == CommentForm.SINGLE_LINE)
                s = $"# {GetCommentText()}";
            else
            {
                if (GetCommentText().Contains("\n") || GetCommentText().Contains("\r\n"))
                {
                    var nSpl = GetCommentText().Split("\n");
                    var rnSpl = GetCommentText().Split("\r\n");
                    var spl = new List<string>();
                    spl.AddRange(nSpl);
                    spl.AddRange(rnSpl);
                    foreach (var sn in spl)
                    {
                        var sx = "# " + sn.Trim();
                        if (s.Length > 0)
                            s += $"\n{sx}";
                        else
                            s = sx;
                    }
                }
                else s = $"# {GetCommentText()}";

                s = $"#:\n{s}\n:#";
            }
            return s;
        }
    }

    public static class FCubedFormatter
    {
        public static string FormatObject(in object o)
        {
            if (o is char)
                return $"'{ConvertTo<char>(o)}'";
            else if (o is bool)
                return ConvertTo<bool>(o).ToString().ToLower();
            else if (o is short || o is Int16)
                return ConvertTo<short>(o).ToString() + 's';
            else if (o is int || o is Int32)
                return ConvertTo<int>(o).ToString();
            else if (o is long || o is Int64)
                return ConvertTo<long>(o).ToString() + 'l';
            else if (o is ushort || o is UInt16)
                return ConvertTo<ushort>(o).ToString() + "us";
            else if (o is uint || o is UInt32)
                return ConvertTo<uint>(o).ToString() + 'u';
            else if (o is ulong || o is UInt64)
                return ConvertTo<ulong>(o).ToString() + "ul";
            else if (o is byte)
                return ConvertTo<byte>(o).ToString() + 'b';
            else return "~";
        }

        private static T ConvertTo<T>(in object o)
            => (T)o;

        private static string GetObjectString(in object o)
            => (string)o;
    }

    public sealed class FCubedProperty
    {
        
    }
}
