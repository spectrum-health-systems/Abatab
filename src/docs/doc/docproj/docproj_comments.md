# Comments

## Types

### Development related

Development related comments should not be removed from the source code, and generally use the `DEPRECIATED`, `DEVNOTE`, `REVIEW`, and `TODO` tags

```csharp
// REVIEW: An example of a development related comment.
```

### Narrative comments

Narrative comments provide additional information about the source code, can be removed, and generally use the `INFO` tags.

```csharp
/* INFO: This is a narrative comment. */

/* INFO: Narrative comments can
 * also be multiple lines.
 */
```

### XML documentation comments

XML documentation comments are part of the source code documentation, and should not be removed.

```csharp
/// XML documentation comments.
```

## Tags

### DEPRECIATED

A block of code that is depreciated, and should be removed.

Max characters: `80`


Example:

```csharp
/* DEPRECIATED: This block of code is no longer needed
 */

or

// DEPRECIATED: This block of code is no longer needed
```

### DEVNOTE / DEVELOPMENT NOTE

Additional information that provides details about a block of code that the reader may not be able to infer from the code itself.

Max characters: `175`

Example:

```csharp
// DEVELOPMENT NOTE
// This block of code does a thing because of a thing.

or

// DEVNOTE: This block of code does a thing because of a thing.
```

Longer development notes can also be at the end of a file:

```csharp
/* DEVELOPMENT NOTE
 * This block of code does a thing
 * because of a thing.
 */
```


### INFO

Additional information that provides details about a block of code that the reader may not be able to infer from the code itself.

Max characters: `175`

Example:

```csharp
/* INFO: This block of code does a thing because of a thing.
 */

or

// INFO: This block of code does a thing because of a thing.
```

### REVIEW

A block of code that needs to be removed, along with notes as to why.

Max characters: `175`

Example:

```csharp
/* REVIEW: There is probably a better way of doing this, maybe x, y, and z.
 */

or

/// REVIEW: There is probably a better way of doing this, maybe x, y, and z.
```

## TODO

A reminder to do something.

Max characters: `175`

Example:

```csharp
/* TODO: Do a thing.
 */

or

// TODO: Do a thing.
```