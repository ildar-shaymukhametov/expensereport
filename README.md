# ExpenseReport
The ExpenseReport legacy code refactoring kata in various languages.

This is an example of a piece of legacy code with lots of code smells.
The goal is to support the following new feature as best as you can:
* Add Lunch with an expense limit of 2000.

## Process
1. 📚 Read the code to understand what it does and how it works.
2. 🦨 Read the code and check for design smells.
3. 🧑‍🔬 Analyze what you would have to change to implement the new requirement without refactoring the code.
4. 🧪 Write a characterization test. Take note of all design smells that you missed that made your life writing a test miserable.
5. 🔧 Refactor the code.
6. 🔧 Refactor the test.
7. 👼 Test-drive the new feature.

## Supported Languages
The ExpenseReport example currently exists in the following languages:
- [Ada](expensereport-ada/)
- [Assembler](expensereport-asm-68k-masm/) (Motorola 68020, Amiga OS, MaxonASM)
- [Assembler](expensereport-asm-amd64-linux-gasm/) (AMD64/Intel x86-64, Linux, GNU Assembler)
- [bash](expensereport-bash/)
- [BASIC](expensereport-basic-amiga/) (Amiga BASIC, Commodore Amiga) ⇐ Quite amazing! First BASIC without line numbers!
- [BASIC](expensereport-basic-bywater/) (Bywater BASIC, Linux) (very similar to Commodore BASIC)
- [BASIC](expensereport-basic-c64/) (Commodore BASIC, Commodore 64)
- [BASIC](expensereport-basic-locomotive/) (Locomotive BASIC, Amstrad CPC)
- [C](expensereport-c/)
- [C#](expensereport-csharp/)
- [C++](expensereport-cxx/)
- [Clojure](expensereport-clojure/) ⇐ This one was particularly painful to intentionally write poorly, I almost cried.
- [COBOL](expensereport-cobol/)
- [D](expensereport-d/)
- [Dart](expensereport-dart/)
- [Elixir](expensereport-elixir/)
- [F#](expensereport-fsharp/)
- [Fortran](expensereport-fortran/)
- [Go](expensereport-go/)
- [Groovy](expensereport-groovy-script/)
- [Haskell](expensereport-haskell/)
- [Java](expensereport-java/)
- [JavaScript](expensereport-javascript/)
- [Julia](expensereport-julia/)
- [Kotlin](expensereport-kotlin/)
- [Lisp](expensereport-lisp/) (Common Lisp)
- [Lua](expensereport-lua/)
- [Nim](expense-report-nim/)
- [Objective-C](expensereport-objc/)
- [Pascal](expensereport-pascal/)
- [Perl](expensereport-perl/)
- [PHP](expensereport-php/)
- [PostScript](expensereport-postscript/)
- [Prolog](expensereport-prolog/)
- [Python](expensereport-python/)
- [Raku](expensereport-raku/) (Perl6)
- [Rexx](expensereport-rexx/) (tested with Regina Rexx and ARexx)
- [Ruby](expensereport-ruby/)
- [Rust](expensereport-rust/)
- [Scala](expensereport-scala/)
- [Scheme](expensereport-scheme/)
- [Smalltalk](expensereport-smalltalk/)
- [SQL](expensereport-sql/) (Using SQLite3)
- [Swift](expensereport-swift/)
- [TcL](expensereport-tcl/)
- [TypeScript](expensereport-typescript/)
- [Visual BASIC](expensereport-vb/)
- [XML/XSLT](expensereport-xslt/)
- [Zig](expensereport-zig/)
- [zsh](expensereport-zsh/)

## Planned languages
(in no particular order and with no guarantee)

- ABAP
- Amiga E
- AMOS BASIC
- APL
- More Assembler implementations (arm, aarch64, i686, powerpc, powerpc64, mpis, mips64, sparc, sparc64, risc-v, etc, usually on Linux)
- Cluster
- Curry
- Dark
- Eiffel
- Elm
- Erlang
- Forth
- Gosu
- Hare
- Java Byte Code / JVM Assembler
- Lobster
- Logo
- Mercury
- Modula-2 (once the linker starts working again)
- Oberon
- OCaml
- R
- REBOL
- Scratch
- TeX
- WebAssembly

## Languages explicitly not planned
- Brainfuck
- False
- Malbolge
- Whitespace

## Solutions
**Warning** The solutions branch will be rebased!

Currently, solutions exist in the following languages:
- [C](expensereport-c/)
- [C#](expensereport-csharp/)
- [C++](expensereport-cxx/)
- [Fortran](expensereport-fortran/)
- [Go](expensereport-go/) (with BDD)
- [Java](expensereport-java/) (with BDD)
- [Kotlin](expensereport-kotlin/) (with BDD)
- [Rust](expensereport-rust/)

### Solution Rationale
- Make adding the new requirement (lunch with an expense limit 2000) as easy and simple and error-free as possible. That means solving the OCP-violations of `printReport()`.
- Small ("atomic") functions. Extract until you can no longer reasonably extract further methods.
- A balance between a language independent design expressed idiomatic in the target language.

## Credits
I first encountered the ExpenseReport example during a bootcamp at Equal Experts.
I also have seen the ExpenseReport example being used by Robert "Uncle Bob" C. Martin.
I have tried to research its origins but so far I have failed.
If you know who has first come up with this example, please get in touch with me.
