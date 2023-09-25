all: build

build: World

World:
	mkdir -p bin
	mcs -langversion:4 -optimize+ -unsafe -t:exe -out:"bin/ruinsandriches.exe" -nowarn:219,414 -d:NEWTIMERS -d:NEWPARENT -d:MONO -reference:System.Drawing -recurse:"src/ruinsandriches/System/Source/*.cs"
