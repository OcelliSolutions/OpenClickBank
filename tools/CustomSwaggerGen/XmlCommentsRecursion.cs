using System.Xml.XPath;

namespace CustomSwaggerGen
{

    /// <summary>
    /// Service to handle recursive retrieval of XML comments from an XPathNavigator.
    /// </summary>
    internal static class XmlCommentsRecursionService
    {
        private const string MemberXPath = "/doc/members/member[@name='{0}']";

        /// <summary>
        /// Retrieves the comment of a specific tag for a given member.
        /// If the tag is not found, it recursively searches for the tag in the inherited documentation.
        /// </summary>
        /// <param name="xmlNavigator"></param>
        /// <param name="memberName">The name of the member for which to retrieve the comment.</param>
        /// <param name="tag">The tag of the comment to retrieve (e.g., "summary", "remarks", "example", etc.).</param>
        /// <returns>The content of the comment tag or an empty string if not found.</returns>
        public static XPathNavigator SelectSingleNodeRecursive(this XPathNavigator xmlNavigator, string memberName,
            string tag)
        {
            while (true)
            {
                var memberNode = xmlNavigator.SelectSingleNode(string.Format(MemberXPath, memberName));

                var node = memberNode?.SelectSingleNode(tag);
                if (node != null)
                    return memberNode;

                var inheritDocNode = memberNode?.SelectSingleNode("inheritdoc");
                if (inheritDocNode == null)
                    return null;

                var cref = inheritDocNode.GetAttribute("cref", string.Empty);
                if (string.IsNullOrEmpty(cref))
                    return null;

                var referencedNode = xmlNavigator.SelectSingleNode(string.Format(MemberXPath, cref));
                if (referencedNode == null)
                    return null;

                memberName = cref;
            }
        }
    }
}