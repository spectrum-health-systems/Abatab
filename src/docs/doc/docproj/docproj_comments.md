# Comments

## Types

```csharp
// Comment
```

```csharp
/// Comment
```

```csharp
/* Comment */
```

```csharp
/*
 * Comment
 */
```

## Tokens

* **INFO**  
Additional information that provides details about a block of code that the reader may not be able to infer from the code itself.

Max characters: `175`

Example:

```csharp
/* INFO: This block of code does a thing because of a thing.
 */
```

* **DEPRECIATED**  
A block of code that is depreciated, and should be removed.

Example:

```csharp
/* DEPRECIATED: This block of code is no longer needed
 */
```

* **REVIEW**  
A block of code that needs to be removed, along with notes as to why.

Example:

```csharp
/* REVIEW: There is probably a better way of doing this, maybe x, y, and z.
 */
```

* **TODO**  
A reminder to do something.