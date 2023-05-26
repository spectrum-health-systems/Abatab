# Comments

## XML documentation

XML documentation is contained in external files.

```csharp
/// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
```

## Types

### Development

Development comments start with `\\`, and generally use the `DEPRECIATED`, `DEVNOTE`, `REVIEW`, and `TODO` tags

Development comments should not be removed from the source code.

```csharp
// TODO: Implement a feature

or

// TODO: Implement a feature
// that is multiple lines.

```

### Narrative comments

Narrative comments are enclosed with `/* */`, provide provide additional information about a block of code, and generally use the `INFO` tag.

Narrative comments can be removed from the source code.

```csharp
/* INFO: Narrative comments can
 * be multiple lines.
 */
```

### XML documentation comments

XML documentation comments start with `\\\`, and are part of the source code documentation.

Development comments should not be removed from the source code.

```csharp
/// XML documentation comments.
```

## Tags

### DEPRECIATED

A block of code that is depreciated, and should be removed.

Example:

```csharp
// DEPRECIATED: This block of code is no longer needed
```

### DEVNOTE

Additional information that provides details about a block of code that the reader may not be able to infer from the code itself.

Example:

```csharp
// DEVNOTE: This block of code does a thing because of a thing.
```

### INFO

Additional information that provides details about a block of code that the reader may not be able to infer from the code itself.

Example:

```csharp
/* INFO: This block of code does a thing because of a thing.
 */
```

### REVIEW

A block of code that needs to be removed, along with notes as to why.

Example:

```csharp
// REVIEW: There is probably a better way of doing this, maybe x, y, and z.
```

## TODO

A reminder to do something.

Example:

```csharp
// TODO: Do a thing.
```
