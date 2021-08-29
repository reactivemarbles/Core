// Copyright (c) 2019-2021 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace ReactiveMarbles.Core
{
    /// <summary>
    /// IReactivePropertyChangedEventArgs is a generic interface that
    /// is used to wrap the NotifyPropertyChangedEventArgs and gives
    /// information about changed properties. It includes also
    /// the sender of the notification.
    /// Note that it is used for both Changing (i.e.'before change')
    /// and Changed Observables.
    /// </summary>
    /// <param name="PropertyName">The property name.</param>
    /// <typeparam name="TSender">The sender type.</typeparam>
    public record RxPropertyChangedEventArgs<TSender>(string PropertyName, TSender Sender) : IRxPropertyEventArgs<TSender>;
}