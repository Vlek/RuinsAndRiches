all: build

build: World

World:
	mcs -langversion:4 -optimize+ -unsafe -t:exe -out:"Bin/World.exe" -nowarn:219,414 -d:NEWTIMERS -d:NEWPARENT -d:MONO -reference:System.Drawing -recurse:"src/ruinsandriches/System/Source/*.cs"
