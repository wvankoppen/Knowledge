

* IDE
  * WebStorm
  * VS2020
  * VS Code
  * Notepad++
  * PowerShell ISE


* Browser
  * Chrome
  * Postman
* Mixed
  * KeePass
  * Foxit Reader
  * NodeJs
  * Putty
  * BulkFileChanger (Change time stamps from files and folders)

* Version control
  * Tortoise SVN
  * Tortoise GIT
  * GIT Bash
  * WinMerge
* Azure
  * Service Bus Explorer
  * Azure CLI
* Hacking
  * Fiddler
  * ILSpy
  * dnSpy (Can decompile Java and .NET assemblies and change them)
* Databases
  * SQL Server Profiler 17 (see queries from EF)
  * Robo3T (RoboMongo Client)





# Grep

egrep = grep -E	echo 123 | egrep "1|2"	You can use special chars like | as or operator

grep -v	Invert pattern


Get version numbers from config files:
grep --recursive --no-filename --extended-regexp --only-matching ./ --regexp '(Priva)(.*)Version(.*)([0-9]|\.)+' --include *.config | sort | uniq


diff --brief -r path1 path2	Give list of different files/folders
find / -type f -exec grep -H 'text-to-find-here' {} \;


The -exec and -ok commands take subsequent parameters on the line as part of their parameters, until terminated with a \; sequence. Effectively, the -exec and -ok commands are executing an embedded command, so that embedded command has to be terminated with an escaped semicolon so that the find command can determine when it should resume looking for command-line options that are intended for
itself. The magic string “{}” is a special type of parameter to an -exec or -ok command and is replaced with the full path to the current file.

That explanation is perhaps not so easy to understand, but an example should make things clearer. Take a look at a simple example, using a nice safe command like ls:

$ find . -newer while2 -type f -exec ls -l {} \;
-rwxr-xr-x 1 rick rick 275 Feb 8 17:07 ./elif3
-rwxr-xr-x 1 rick rick 336 Feb 8 16:52 ./words.txt
-rwxr-xr-x 1 rick rick 1274 Feb 8 16:52 ./words2.txt
-rwxr-xr-x 1 rick rick 504 Feb 8 18:43 ./_trap


