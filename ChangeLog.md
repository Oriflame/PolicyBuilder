# Change log

## 4.1.0
- `ForwardRequest` policy - optional attribute builder adjustments - allow to set `follow-redirects`, `buffer-request-body`, `buffer-response`, `fail-on-error-status-code`, `timeout` using `string` values
- 
## 4.0.0

- New policies `DeleteHeader` and `DeleteQueryParameter`
- `ExistAction.Delete` marked as `Obsolete` - replaced with new policies `DeleteHeader` and `DeleteQueryParameter`
- `ContextVariable` extended with `GetValueOrDefault` method
- `ForwardRequest` policy - added optional attribute builder - allow to set `follow-redirects`, `buffer-request-body`, `buffer-response`, `fail-on-error-status-code`, `timeout` optional attributes

## 3.5.0

- added new attribute `CachingType` to `CacheStoreValue` and `CacheLookupValue` policies

## 3.4.0

- `ContextRequest` and `ContextResponse` - added support for getting body as JArray (`GetBodyAsJArray()` method)

## 3.3.0

- `CacheStore` policy - added optional attribute builder - allows to set `cache-response` optional attribute
- Code refactoring - split main policy section builders (Inbound, outbound...) into partial classes by policy

## 3.2.2

- No changes
- New version just due to new Nuget package version to fix the issue with upload

## 3.2.1

- No changes
- New version just due to new Nuget package version to fix the issue with upload 

## 3.2.0

- `CacheStore` policy - `duration` parameter can be defined as string

## 3.1.0

- `validate-jwt` policy - added support for `require-scheme` and `output-token-variable-name` attributes


## 3.0.1

- `SendRequest` policy extension - `timeout` parameter can be defined as string

## 3.0.0

- The PolicyBuilder repo is being versioned by tags with semantic versioning.
