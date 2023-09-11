// Copyright (c) 2019-2023 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.IO;
using ReactiveMarbles.Mvvm.SourceGenerator.Roslyn38;
using Xunit.Abstractions;

namespace ReactiveMarbles.Mvvm.SourceGenerator.Tests;

public class ValueBinderGenerator38Tests : TestBase<AsValueGenerator38>
{
    public ValueBinderGenerator38Tests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper, string.Empty)
    {
    }

    [Fact]
    public void Given_When_Then()
    {
        // Given
        var testObjectFile = TestUtilities.GetTestPath("TestObject.cs");
        var fileStream = File.OpenRead(testObjectFile);
        var reader = new StreamReader(fileStream);

        var file = reader.ReadToEnd();

        // When

        // Then
    }
}
