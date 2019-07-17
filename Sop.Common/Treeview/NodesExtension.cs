using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sop.Common.Treeview
{
    public static class NodesExtension
    {


        public static IEnumerable<BootstrapNode> ToNodes(this IEnumerable<NodeInfo> listInfos)
        {
            var infos = listInfos as NodeInfo[] ?? listInfos.ToArray();

            var rootCategorys = infos?.Where(x => x.ParentId == 0);

            var nodes = new List<BootstrapNode>();
            foreach (var info in rootCategorys)
            {
                var node = new BootstrapNode();
                node.Id = info.Id.ToString();
                node.Text = info.Name;
                node.Tags = new string[] { info.ChildCount.ToString() };

                OrganizeForIndented(node.Nodes, node, info, infos);
                nodes.Add(node);

            }
            return nodes;


        }
        /// <summary>
        /// 收缩递归
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="node"></param>
        /// <param name="info"></param>
        /// <param name="lists"></param>
        private static void OrganizeForIndented(List<BootstrapNode> nodes, BootstrapNode node, NodeInfo info, IEnumerable<NodeInfo> lists)
        {
            if (info.ChildCount > 0)
            {
                nodes = new List<BootstrapNode>();
                var newlists = lists?.Where(x => x.ParentId == info.Id);
                foreach (var info1 in newlists)
                {
                    BootstrapNode node1 = new BootstrapNode
                    {
                        Id = info1?.Id.ToString(),
                        Text = info1.Name,
                        Tags = new string[] { info1?.ChildCount.ToString() }
                    };
                    OrganizeForIndented(node1.Nodes, node1, info1, lists);
                    nodes.Add(node1);
                }
                node.Nodes = nodes;
            }
        }
         
    }
}
