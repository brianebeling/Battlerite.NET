# Battlerite.NET

**.Net Standard Library** for [Battlerites](https://developer.battlerite.com/) Official API

### THIS PROJECT IS NOT LONGER MAINTAINED. ###

There is missing documentation, random exceptions and lots of TODOs. If you want to take the challenge, go ahead.
The decision was made because Stunlock Studios recent announcement that Battlerite Royale will be another Game as opposed to Mode (as promised!),
the lack of communication with the API devs and an overall mistrust in Sunluck Studios. I maybe will pick this up
at a later date and fix all the remaining bugs and todos. But only if Stunluck Studios can actually deliver and
Battlerite Royale won't be a complete disaster playerbase wise.

## Installation

It is recommended to use the metapackage which contains all key components and should be sufficient in the majority of cases.
For the more specific cases each package is also available individually.

### Packages

Battlerite.NET is split into multiple packages. Each package represents a key component.

#### [Battlerite.NET](https://www.nuget.org/packages/Rethought.Battlerite.NET/)

The metapackage combining all packages below

#### [Battlerite.NET.Assets](https://www.nuget.org/packages/Rethought.Battlerite.NET.Assets/)

This package contains everything related to [Assets](https://github.com/StunlockStudios/battlerite-assets).
These are used to map values from the Battlerite API to localized Strings or to more meta Informations.

#### [Battlerite.NET.Rest](https://www.nuget.org/packages/Rethought.Battlerite.NET.Rest/)

This package interacts with the official Battlerite API. It also utilizes Battlerite.NET.Assets to populate meta informations.

## Caching

Some packages may provide an option for caching. For this purpose Battlerite.NET heavily relies on [CacheManager](https://github.com/MichaCo/CacheManager). An Open-Source Caching Abstraction Layer with many different integrations, such as Redis and Couchebase.

However, **caching is optional** and only added on top of existing abstractions. You can easily replace it with your own caching solutions and is only meant to support developers that don't want to do it on their own.

## Documentation

Documentation will be available in a GitHub Wiki. This ReadMe is only a temporary solution.