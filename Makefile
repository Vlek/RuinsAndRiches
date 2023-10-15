all: build

build: World

World:
	rm -rf ./bin/
	mkdir -p ./bin/Data
	mcs \
    -langversion:4 \
		-optimize+ \
		-win32icon:"src/ruinsandriches/System/Source/icon.ico" \
		-unsafe \
		-t:exe  \
		-out:"bin/ruinsandriches.exe" \
		-nowarn:219,414 \
		-d:NEWTIMERS \
		-d:NEWPARENT \
		-d:MONO \
		-reference:System.Drawing \
		-reference:System.Data \
		-reference:System.Web \
		-reference:System.Windows.Forms \
		-recurse:"src/ruinsandriches/*.cs"
	cd src/ruinsandriches; cp -r Decoration Scripts Spawns Files System ../../bin/Data
	cd bin; zip -q -r ruinsandriches.zip *
