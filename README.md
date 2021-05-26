# ChatBot
Chatbot API with option to call external API with some basic Frontend

Tech details:


Common issues during building angular project ChatBotFront:
1.
An unhandled exception occurred: Cannot find module '**@angular/compiler-cli**'
Require stack:
- C:\Users\kelld\node_modules\@ngtools\webpack\src\ivy\plugin.js
- C:\Users\kelld\node_modules\@ngtools\webpack\src\ivy\index.js
- C:\Users\kelld\node_modules\@ngtools\webpack\src\index.js

To fix that:

**npm ls @angular-devkit/schematics**

If it returns (empty)

**npm install @angular-devkit/schematics**

Then try build project via ng serve... if still there is problem try restore packages
**git restore package-lock.json
git restore package.json**
or update angular cli
**ng update @angular/core @angular/cli**

2. If the Send button does not work please double check the port where API is hosted and adjust it in file (**code line 23**): **C:\Users\kelld\OneDrive\Pulpit\ChatBot\ChatBot\ChatBotFront\src\app\containers\chat\chat.component.ts**
