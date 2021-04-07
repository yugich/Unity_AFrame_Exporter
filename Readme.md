## Under Development

### Creating new objects into scene
Remenber: To export the project we recomend create at least
- AFrame Camera 
- Directional Light

![alt text](https://github.com/yugich/Unity_AFrame_Exporter/blob/master/Documentation/Images/createNewObject.png)

### Exporting scene to AFrame
![alt text](https://github.com/yugich/Unity_AFrame_Exporter/blob/master/Documentation/Images/sceneExporter.png)
Warning! If you have any custom object (GLTF model) in your scene, to work the HTML you need host your project like a [Surge](https://surge.sh) platform

### Dependences to use GLTF Models
Newtonsoft - https://github.com/jilleJr/Newtonsoft.Json-for-Unity

GLTFUtility - https://github.com/Siccity/GLTFUtility

### Exporting GLTF from blender
- Delete all parents and unecessary objects like: Camera, Lights, etc.
- Export gltf just the object without parents

### TO DO
- [x] Export primitives with world positions
- [x] Export Lights
- [x] Export Camera with simple player moviment
- [x] Export custom GLTF
- [ ] Export Billboard 2D Images
- [ ] Export UI
- [ ] Export Simple JS Code translated from C#
- [ ] Under Planing (What you need)
