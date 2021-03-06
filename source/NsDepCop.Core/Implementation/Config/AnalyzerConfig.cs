using System;
using System.Collections.Generic;
using Codartis.NsDepCop.Core.Interface.Config;

namespace Codartis.NsDepCop.Core.Implementation.Config
{
    /// <summary>
    /// Describes the config for a dependency analyzer. Immutable.
    /// </summary>
    [Serializable]
    internal class AnalyzerConfig : IAnalyzerConfig
    {
        public bool IsEnabled { get; }
        public IssueKind IssueKind { get; }
        public Importance InfoImportance { get; }
        public TimeSpan[] AnalyzerServiceCallRetryTimeSpans { get; }

        public bool ChildCanDependOnParentImplicitly { get; }
        public Dictionary<NamespaceDependencyRule, TypeNameSet> AllowRules { get; }
        public HashSet<NamespaceDependencyRule> DisallowRules { get; }
        public Dictionary<Namespace, TypeNameSet> VisibleTypesByNamespace { get; }
        public int MaxIssueCount { get; }
        public IssueKind MaxIssueCountSeverity { get; }
        public bool AutoLowerMaxIssueCount { get; }

        public AnalyzerConfig(
            bool isEnabled, 
            IssueKind issueKind, 
            Importance infoImportance,
            TimeSpan[] analyzerServiceCallRetryTimeSpans,
            bool childCanDependOnParentImplicitly, 
            Dictionary<NamespaceDependencyRule, TypeNameSet> allowRules, 
            HashSet<NamespaceDependencyRule> disallowRules, 
            Dictionary<Namespace, TypeNameSet> visibleTypesByNamespace, 
            int maxIssueCount,
            IssueKind maxIssueCountSeverity,
            bool autoLowerMaxIssueCount)
        {
            IsEnabled = isEnabled;
            IssueKind = issueKind;
            InfoImportance = infoImportance;
            AnalyzerServiceCallRetryTimeSpans = analyzerServiceCallRetryTimeSpans;

            ChildCanDependOnParentImplicitly = childCanDependOnParentImplicitly;
            AllowRules = allowRules;
            DisallowRules = disallowRules;
            VisibleTypesByNamespace = visibleTypesByNamespace;
            MaxIssueCount = maxIssueCount;
            MaxIssueCountSeverity = maxIssueCountSeverity;
            AutoLowerMaxIssueCount = autoLowerMaxIssueCount;
        }

        public IEnumerable<string> ToStrings()
        {
            yield return $"IsEnabled={IsEnabled}";
            yield return $"IssueKind={IssueKind}";
            yield return $"InfoImportance={InfoImportance}";
            yield return $"AnalyzerServiceCallRetryTimeSpans={string.Join(",", AnalyzerServiceCallRetryTimeSpans)}";

            yield return $"ChildCanDependOnParentImplicitly={ChildCanDependOnParentImplicitly}";
            foreach (var s in AllowRules.ToStrings()) yield return s;
            foreach (var s in DisallowRules.ToStrings()) yield return s;
            foreach (var s in VisibleTypesByNamespace.ToStrings()) yield return s;
            yield return $"MaxIssueCount={MaxIssueCount}";
            yield return $"MaxIssueCountSeverity={MaxIssueCountSeverity}";
        }
    }
}