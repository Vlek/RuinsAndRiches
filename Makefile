all: build

build: World

World:
	mcs -optimize+ -unsafe -t:exe -out:"Bin/World.exe" -nowarn:219,414 -d:NEWTIMERS -d:NEWPARENT -d:MONO -reference:System.Drawing -recurse:"System/Source/*.cs"
