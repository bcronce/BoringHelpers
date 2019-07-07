# BoringHelpers
[![Licence](https://img.shields.io/github/license/bcronce/BoringHelpers.svg)](LICENSE)
[![Build Status](https://travis-ci.org/bcronce/BoringHelpers.svg?branch=master)](https://travis-ci.org/bcronce/BoringHelpers)
[![NuGet](https://img.shields.io/nuget/v/BoringHelpers.svg)](https://www.nuget.org/packages/BoringHelpers/)

General use library inspired by common patterns seen in production code.

The goal of this project is to help make code easier to read and more efficient. Secondary to that is to learn and practice CI, high coverage unit testing, and otherwise polishing code to a degree that one many times cannot at work.

I love myself a good philosophical debate about code. Feel free to provide constructive criticism.

# Collections
Light weight collections that implement common interfaces.
## Empty
It is common to have to pass an empty collection. While there exists some common ones in the BCL like `Array.Empty` or `Enumerable.Empty`, they are spread around, sub-optimal, and there is not an `Empty` for all of the common interfaces.

Empty collection are special in that many aspects of them can be stateless. For example, there is no reason to allocate a new enumerator when iterating them.
## Individual
In my expereience, it is very common to have a collection of a single element. While I wanted to name it `Single`, that conflicts with a synonym with `Float`.

I can't tell you how many times I've seen `new Dictionary {{ key, value }}`. Not only does the `Dictionary` collection need to make an `Array`, it also needs to hash the key. When working with a single collection, you can just hold the single `KeyValue` and skip hashing on both creation and lookups. Similar optimizations can be made to other collections when you only have a single element.

Also in my expereience, many of these single element collections tend to be allocated in hot paths. Sizable reductions in GC and CPU time can be had while making the code easier to read. Win-win-win.
