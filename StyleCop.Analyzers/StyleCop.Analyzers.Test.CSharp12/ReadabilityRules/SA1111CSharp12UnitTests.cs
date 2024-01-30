// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Test.CSharp12.ReadabilityRules
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.Testing;
    using StyleCop.Analyzers.Test.CSharp11.ReadabilityRules;
    using Xunit;
    using static StyleCop.Analyzers.Test.Verifiers.StyleCopCodeFixVerifier<
        StyleCop.Analyzers.ReadabilityRules.SA1111ClosingParenthesisMustBeOnLineOfLastParameter,
        StyleCop.Analyzers.SpacingRules.TokenSpacingCodeFixProvider>;

    public partial class SA1111CSharp12UnitTests : SA1111CSharp11UnitTests
    {
        [Fact]
        public async Task TestClassPrimaryConstructorAsync()
        {
            var testCode = @"
public class MyType(int X, int y
    )
{
}";
            var fixedCode = @"
public class MyType(int X, int y)
{
}";

            DiagnosticResult expected = Diagnostic().WithSpan(3, 5, 3, 6);
            await VerifyCSharpFixAsync(testCode, expected, fixedCode, CancellationToken.None).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestStructPrimaryConstructorAsync()
        {
            var testCode = @"
public struct MyType(int X, int y
    )
{
}";
            var fixedCode = @"
public struct MyType(int X, int y)
{
}";

            DiagnosticResult expected = Diagnostic().WithSpan(3, 5, 3, 6);
            await VerifyCSharpFixAsync(testCode, expected, fixedCode, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
