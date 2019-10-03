# A Simple Parser For Notable

When provided a path for a markdown file of definitions, a path for a markdown file of todo lists, and a path for a folder of markdown files, the parser will read all markdown files, and extract any todo item, adding it to the todo list, and any definition, adding it to the definition list



## Definitions

Definitions are defined as lines containing the following:

```Markdown
- > *Def*: **Name**: Definition
```

## Todo Item

Todo items are definted as lines containing:

```
- [ ] todo item 
```

