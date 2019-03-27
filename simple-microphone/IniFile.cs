
/**********************************************************
 * 
 * 命名空间：
 *          simple_microphone
 * 
 * 描述：
 *          N/A
 *          
 * 功能及上下游：
 *          N/A
 *          
 * 人员：
 *          大鱼
 *          
 * 创建时间：
 *          2019/03/27 14:34:24
 * 
 ***********************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace simple_microphone
{
    public class IniFile
    {
        private string iniFileName = string.Empty;
        public const string stetement = "#设置配置文件";

        public IniFile(string iniFileName)
        {
            if (string.IsNullOrEmpty(iniFileName))
            {
                return;
            }

            this.iniFileName = iniFileName;

            // TODO
            initIniPath();
        }

        private void initIniPath()
        {
            FileInfo info = new FileInfo(iniFileName);
            if (!info.Directory.Exists)
            {
                info.Directory.Create();
            }
        }

        # region Write

        public bool WriteString(string nodeName, string attributeKey, string attributeValue, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, attributeKey, attributeValue, charset)) { return false; }

            try
            {
                IniFileData iniFileData = Read(charset);
                return WriteIniFile(nodeName, attributeKey.Replace("=", GetKeywordReplace("=")), attributeValue.Replace("=", GetKeywordReplace("=")), iniFileData, charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool WriteIniFile(string nodeName, string attributeKey, string attributeValue, IniFileData iniFileData, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, attributeKey, attributeValue, charset)) { return false; }

            try
            {
                if (iniFileData == null || !iniFileData.contains(nodeName))
                {
                    return AddNewIniFileNode(nodeName, attributeKey, attributeValue, iniFileData, charset);
                }
                else
                {
                    return UpdateIniFile(nodeName, attributeKey, attributeValue, iniFileData, charset);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool WriteInteger(string nodeName, string attributeKey, int attributeValue, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, attributeKey, charset)) { return false; }

            try
            {
                return WriteString(nodeName, attributeKey, attributeValue + "", charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool WriteDouble(string nodeName, string attributeKey, double attributeValue, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, attributeKey, charset)) { return false; }

            try
            {
                return WriteString(nodeName, attributeKey, attributeValue + "", charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool WriteBool(string nodeName, string attributeKey, bool attributeValue, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, attributeKey, charset)) { return false; }

            try
            {
                return WriteString(nodeName, attributeKey, attributeValue + "", charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增一个新的 ini node 节点
        /// </summary>
        /// <param name="nodeName">node 节点名称</param>
        /// <param name="attributeKey">节点 key</param>
        /// <param name="attributeValue">节点 value</param>
        /// <param name="iniFileData"></param>
        /// <param name="charset">字符编码</param>
        /// <returns>true:添加成功 / false:添加失败</returns>
        private bool AddNewIniFileNode(string nodeName, string attributeKey, string attributeValue, IniFileData iniFileData, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, attributeKey, attributeValue, charset))
            {
                return false;
            }

            StringBuilder builder = new StringBuilder();

            if (iniFileData != null)
            {
                builder.Append(iniFileData.toString());
            }

            builder.Append(string.Concat("[", nodeName, "]"));
            builder.Append(Environment.NewLine);
            builder.Append(attributeKey);
            builder.Append("=");
            builder.Append(attributeValue);
            builder.Append(Environment.NewLine);

            try
            {
                return WriteIniFile(builder.ToString(), charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool UpdateIniFile(string nodeName, string attributeKey, string attributeValue, IniFileData iniFileData, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, attributeKey, attributeValue, charset)) { return false; }

            try
            {
                iniFileData.Update(nodeName, attributeKey, attributeValue);
                return WriteIniFile(iniFileData.toString(), charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool WriteIniFileData(IniFileData data, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(charset)) { return false; }
            if (data == null) { return false; }

            try
            {
                return WriteIniFile(data.toString(), charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 真正的写文件操作
        /// </summary>
        /// <param name="content">写入内容</param>
        /// <param name="charset">字符编码</param>
        /// <returns>true:写入成功 / false:写入失败</returns>
        private bool WriteIniFile(string content, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(content, charset)) { return false; }

            try
            {
                using (FileStream writeStream = new FileStream(iniFileName, FileMode.Truncate))
                {
                    byte[] data = Encoding.GetEncoding(charset).GetBytes(content);
                    writeStream.Write(data, 0, data.Length);

                    // 清空缓冲区、关闭流
                    writeStream.Flush();
                    writeStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        # endregion

        # region Read

        public string ReadString(string nodeName, string key, string defaultString = "", string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, key, charset)) { return defaultString; }

            string resultValue = string.Empty;
            try
            {
                IniFileData allData = Read(charset);
                if (allData == null)
                {
                    return defaultString;
                }

                resultValue = allData.getValueByNodenameAndKey(nodeName, key.Replace("=", GetKeywordReplace("=")));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultValue;
        }

        public int ReadInteger(string nodeName, string key, int defaultInt = 0, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, key, charset))
            {
                return defaultInt;
            }

            int resultValue = defaultInt;

            try
            {
                string value = ReadString(nodeName, key, charset);
                if (!int.TryParse(value, out resultValue))
                {
                    resultValue = defaultInt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultValue;
        }

        public double ReadDouble(string nodeName, string key, double defaultDouble = 0, string charset = "UTF-8")
        {
            double resultValue = defaultDouble;
            if (HasParamsNullOrEmpty(nodeName, key, charset))
            {
                return resultValue;
            }

            try
            {
                string value = ReadString(nodeName, key, charset);
                if (!double.TryParse(value, out resultValue))
                {
                    resultValue = defaultDouble;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultValue;
        }

        public bool ReadBool(string nodeName, string key, bool defaultBool = false, string charset = "UTF-8")
        {
            bool resultValue = defaultBool;
            if (HasParamsNullOrEmpty(nodeName, key, charset))
            {
                return resultValue;
            }

            string value = string.Empty;
            try
            {
                value = ReadString(nodeName, key, charset);
                if (!bool.TryParse(value, out resultValue))
                {
                    resultValue = defaultBool;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultValue;
        }

        public List<string> ReadALLNodeNames(List<string> list = null, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(charset))
            {
                return list;
            }

            IniFileData allData = null;
            try
            {
                allData = Read(charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (allData == null)
            {
                return list;
            }

            ISet<IniFileNode> nodes = allData.getIniFileNode();

            List<string> nodeNames = new List<string>();
            foreach (IniFileNode node in nodes)
            {
                nodeNames.Add(node.getNodeName());
            }

            return nodeNames;
        }

        public List<string> ReadALLValues(string nodeName, List<string> defaultList = null, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, charset))
            {
                return defaultList;
            }

            IniFileNode fileNode = null;

            try
            {
                fileNode = ReadByNode(nodeName, charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (fileNode == null)
            {
                return defaultList;
            }

            List<string> list = new List<string>();
            Dictionary<string, string> attributes = fileNode.getAttributesDictionary();
            foreach (var item in attributes)
            {
                list.Add(item.Value);
            }

            return list;
        }

        public Dictionary<String, String> ReadNodeData(String nodeName, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, charset))
            {
                return null;
            }

            IniFileNode fileNode = null;

            try
            {
                fileNode = ReadByNode(nodeName, charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (fileNode == null)
            {
                return null;
            }

            return fileNode.getAttributesDictionary();
        }

        private IniFileData ReadIniFile(string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(charset))
            {
                return null;
            }

            string iniFileContent = null;

            try
            {
                iniFileContent = ReadToString(charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (String.IsNullOrEmpty(iniFileContent))
            {
                return null;
            }
            string[] dataSegments = Split(iniFileContent, Environment.NewLine);

            IniFileData data = new IniFileData();
            IniFileNode node = null;
            foreach (string segment in dataSegments)
            {
                if (String.IsNullOrEmpty(segment))
                {
                    continue;
                }

                if (segment.StartsWith("#"))
                {
                    data.setStatement(segment);
                    continue;
                }

                if (segment.StartsWith("["))
                {
                    node = new IniFileNode(segment.Substring(1, segment.Length - 2));
                }
                else
                {
                    string[] attributes = Split(segment, "=");
                    if (node != null)
                    {
                        node.push(attributes[0], attributes[1]);
                    }
                }

                if (node != null)
                {
                    data.add(node);
                }
            }

            return data;
        }

        /// <summary>
        /// 真正的数据读取操作
        /// </summary>
        /// <param name="charset">字符编码</param>
        /// <returns>读取的字符串数据</returns>
        private string ReadToString(string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(charset)) { return null; }

            try
            {
                using (FileStream readStream = new FileStream(iniFileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    int fileLength = (int)readStream.Length;
                    byte[] dataByteArray = new byte[fileLength];
                    readStream.Read(dataByteArray, 0, fileLength);

                    readStream.Close();

                    return Encoding.GetEncoding(charset).GetString(dataByteArray);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IniFileNode ReadByNode(string nodeName, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, charset)) { return null; }

            IniFileNode resultNode = null;

            IniFileData allData = Read(charset);
            if (allData == null) { return null; }

            ISet<IniFileNode> nodes = allData.getIniFileNode();
            foreach (IniFileNode node in nodes)
            {
                if (node.getNodeName().Equals(nodeName))
                {
                    resultNode = node;
                    break;
                }
            }

            return resultNode;
        }

        private IniFileData Read(string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(charset)) { return null; }

            IniFileData data = null;
            try
            {
                data = ReadIniFile(charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        # endregion

        # region Check

        public bool KeyExists(string nodeName, string key, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, key, charset))
            {
                return false;
            }

            try
            {
                string value = ReadString(nodeName, key, charset);
                if (String.IsNullOrEmpty(value))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        # endregion

        # region Remove

        public bool RemoveNode(string nodeName, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, charset)) { return false; }

            try
            {
                IniFileData data = Read(charset);
                data.remove(nodeName);

                WriteIniFileData(data, charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool RemoveKey(string nodeName, string key, string charset = "UTF-8")
        {
            if (HasParamsNullOrEmpty(nodeName, key, charset)) { return false; }

            try
            {
                IniFileData data = Read(charset);
                data.remove(nodeName, key.Replace("=", GetKeywordReplace("=")));

                WriteIniFileData(data, charset);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        # endregion

        # region Utils

        /// <summary>
        /// 判断参数列表中是否有为空的参数
        /// </summary>
        /// <param name="paramList">参数列表</param>
        /// <returns>true:存在空参数 / false:没有为空的参数</returns>
        private static bool HasParamsNullOrEmpty(params string[] paramList)
        {
            foreach (string param in paramList)
            {
                if (String.IsNullOrEmpty(param))
                {
                    return true;
                }
            }
            return false;
        }

        private static string GetKeywordReplace(string keyword)
        {
            Dictionary<string, string> keywordReplaceDictionary = new Dictionary<string, string>();

            keywordReplaceDictionary.Add("=", "#等于#");

            return keywordReplaceDictionary[keyword];
        }

        /// <summary>
        /// 基于原 Split 的优化，适用于字符的 Split
        /// </summary>
        /// <param name="match">待 split 的字符串</param>
        /// <param name="pattern">split 的分隔符</param>
        /// <returns>分隔后的字符串数组</returns>
        private static string[] Split(string match, string pattern)
        {
            Regex regex = new Regex(pattern);
            string[] segments = regex.Split(match);

            return segments;
        }

        # endregion

    }

    public class IniFileData
    {
        private string statement = string.Empty;
        private ISet<IniFileNode> nodes = null;

        public IniFileData()
        {
            nodes = new HashSet<IniFileNode>();
        }

        public ISet<IniFileNode> getIniFileNode()
        {
            return nodes;
        }

        public bool contains(string nodeName)
        {
            if (nodes == null)
            {
                return false;
            }

            foreach (IniFileNode node in nodes)
            {
                if (node.getNodeName().Equals(nodeName))
                {
                    return true;
                }
            }

            return false;
        }

        public void add(IniFileNode node)
        {
            if (node == null)
            {
                return;
            }

            nodes.Add(node);
        }

        public void Update(string nodeName, string attributeKey, string attributeValue)
        {
            if (nodes == null)
            {
                return;
            }

            foreach (IniFileNode node in nodes)
            {
                if (node.getNodeName().Equals(nodeName))
                {
                    if (node.contains(attributeKey))
                    {
                        node.update(attributeKey, attributeValue);
                    }
                    else
                    {
                        node.push(attributeKey, attributeValue);
                    }
                }
            }
        }

        public void setStatement(string statement)
        {
            this.statement = statement;
        }

        public string getStatement()
        {
            return statement;
        }

        public IniFileNode getIniFileNodeByNodename(string nodeName)
        {
            IniFileNode resultNode = null;

            foreach (IniFileNode node in nodes)
            {
                if (node.getNodeName().Equals(nodeName))
                {
                    resultNode = node;
                    break;
                }
            }

            return resultNode;
        }

        public string getValueByNodenameAndKey(string nodeName, string key)
        {
            IniFileNode node = getIniFileNodeByNodename(nodeName);
            if (node == null)
            {
                return null;
            }

            return node.getValueByKey(key);
        }

        public string toString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getStatement());
            builder.Append(Environment.NewLine);
            foreach (IniFileNode node in nodes)
            {
                builder.Append("[");
                builder.Append(node.getNodeName());
                builder.Append("]");
                builder.Append(Environment.NewLine);

                Dictionary<string, string> attributes = node.getAttributesDictionary();
                foreach (var item in attributes)
                {
                    builder.Append(string.Concat(item.Key, "=", item.Value));
                    builder.Append(Environment.NewLine);
                }
            }

            return builder.ToString();
        }

        public void remove(string nodeName)
        {
            foreach (IniFileNode node in nodes)
            {
                if (node.getNodeName().Equals(nodeName))
                {
                    nodes.Remove(node);
                    break;
                }
            }
        }

        public void remove(string nodeName, string key)
        {
            foreach (IniFileNode node in nodes)
            {
                if (node.getNodeName().Equals(nodeName))
                {
                    Dictionary<string, string> attributes = node.getAttributesDictionary();
                    if (attributes != null)
                    {
                        attributes.Remove(key);
                    }

                    break;
                }
            }
        }
    }

    public class IniFileNode
    {
        private string nodeName = string.Empty;
        private Dictionary<string, string> attributes = null;

        public IniFileNode()
        {
            attributes = new Dictionary<string, string>();
        }

        public IniFileNode(string nodeName)
        {
            this.nodeName = nodeName;
            attributes = new Dictionary<string, string>();
        }

        public void setNodeName(string nodeName)
        {
            this.nodeName = nodeName;
        }

        public string getNodeName()
        {
            return this.nodeName;
        }

        public Dictionary<string, string> getAttributesDictionary()
        {
            return attributes;
        }

        public void setAttributesDictionary(Dictionary<string, string> attributesDictionary)
        {
            this.attributes = attributesDictionary;
        }

        public void push(string key, string value)
        {
            if (attributes == null)
            {
                attributes = new Dictionary<string, string>();
            }

            attributes.Add(key, value);
        }

        public void clear()
        {
            if (attributes != null)
            {
                attributes.Clear();
            }
        }

        public bool contains(string key)
        {
            return attributes.ContainsKey(key);
        }

        public void update(string key, string value)
        {
            attributes[key] = value;
        }

        public string getValueByKey(string key)
        {
            if (attributes != null && attributes.ContainsKey(key))
            {
                return attributes[key];
            }

            return null;
        }

        public string toString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(getNodeName());
            builder.Append(Environment.NewLine);
            foreach (var item in attributes)
            {
                builder.Append(string.Concat(item.Key, "=", item.Value));
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
