ModName="Pacifist"

# function for xml reading
read_dom () {
    local IFS=\>
    read -d \< ENTITY CONTENT
}

# read install folder from environment
while read_dom; do
	if [[ $ENTITY = "VALHEIM_INSTALL" ]]; then
		VALHEIM_INSTALL=$CONTENT
	fi
	if [[ $ENTITY = "R2MODMAN_INSTALL" ]]; then
		R2MODMAN_INSTALL=$CONTENT
	fi
	if [[ $ENTITY = "USE_R2MODMAN_AS_DEPLOY_FOLDER" ]]; then
		USE_R2MODMAN_AS_DEPLOY_FOLDER=$CONTENT
	fi
done < Environment.props

# set ModDir
if $USE_R2MODMAN_AS_DEPLOY_FOLDER; then
	PluginFolder="$R2MODMAN_INSTALL/BepInEx/plugins"
else
	PluginFolder="$VALHEIM_INSTALL/BepInEx/plugins"
fi

ModDir="$PluginFolder/$ModName"

# copy content
echo Coping to: "$ModDir"
mkdir -p "$ModDir"
cp "$ModName/obj/Debug/$ModName.dll" "$ModDir"
cp README.md "$ModDir"
cp manifest.json "$ModDir"
cp icon.png "$ModDir"

cd "$ModDir" || exit

[ -f "$ModName.zip" ] && rm "$ModName.zip"
[ -f "$ModName-Nexus.zip" ] && rm "$ModName-Nexus.zip"

mkdir -p plugins
cp "$ModName.dll" plugins

zip "$ModName.zip" "$ModName.dll" README.md manifest.json icon.png
zip -r "$ModName-Nexus.zip" plugins

rm -r plugins
