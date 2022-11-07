# Comments

Attempts have been made to make the Abatab source code as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWSC sourcecode:

## XML comments

XML comments are used by DocFx to create the source code documentation.

```#bash
/// <summary>
/// The main Abatab project, and where the magic starts.
/// </summary>
```

## Developer comments

```#bash
// Comments starting with `"//"` are developer comments that are intended to provide important information about source code that may not be clear. Developer comments should not be removed.
```

## Narrative comments

```#bash
/* Comments that start with `"/*"` and end with `"*/"` are narrative comments that provide additional details about source code that may be interesting to the reader, and may be removed. */
```

```#bash
/* Narrative comments can 
 * also be
 * multi-line. 
 */
```
