// Copyright (c) 2019-2022 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace ReactiveMarbles.Mvvm.SourceGenerator.Shared
{
    /// <summary>
    /// Helps source generation.
    /// </summary>
    public static class GeneratorHelper
    {
        /// <summary>
        /// Generate as value property.
        /// </summary>
        /// <param name="addFileNameAndSourceText">A callback to add source text.</param>
        /// <param name="addDiagnostic">A callback to add a diagnostic message.</param>
        /// <param name="compilation">The compilation.</param>
        /// <param name="invocations">The invocation expressions.</param>
        public static void GenerateAsValueProperty(
            Action<string, string> addFileNameAndSourceText,
            Action<Diagnostic> addDiagnostic,
            Compilation compilation,
            IEnumerable<InvocationExpressionSyntax> invocations)
        {
            var validInvocations = new List<IMethodSymbol>();
            foreach (var invocation in invocations)
            {
                if (compilation.GetSemanticModel(invocation.SyntaxTree).GetSymbolInfo(invocation).Symbol is not
                    IMethodSymbol methodSymbol)
                {
                    continue;
                }

                if (methodSymbol.Parameters.Length != 2)
                {
                    continue;
                }

                if (methodSymbol.Parameters[1].Type.SpecialType != SpecialType.System_String)
                {
                    continue;
                }

                if (!methodSymbol.Parameters[0].Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)
                        .StartsWith("global::System.IObservable"))
                {
                    continue;
                }

                validInvocations.Add(methodSymbol);
            }
        }

        /// <summary>
        /// Checks if the provided <see cref="SyntaxNode"/> is an AsValue node.
        /// </summary>
        /// <param name="syntax">The syntax node.</param>
        /// <returns>A value indicating whether the node is an as value node.</returns>
        public static bool IsAsValueNode(SyntaxNode syntax) => syntax is InvocationExpressionSyntax
        {
            Expression:
            MemberAccessExpressionSyntax { Name.Identifier.Text: "AsValue" } or
            MemberBindingExpressionSyntax { Name.Identifier.Text: "AsValue" }
        };

        private static string SourceCode(IEnumerable<IMethodSymbol> validInvocations)
        {
            foreach (var observableGrouping in validInvocations.GroupBy(x => x.Parameters[0].Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)))
            {
                foreach (var symbol in observableGrouping.Select(x => x.Parameters[1]).Distinct())
                {
                }
            }

            return string.Empty;
        }
    }
}
