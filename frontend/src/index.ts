import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { OhVueIcon, addIcons } from "oh-vue-icons"
import { allIcons } from './models/icons/Icons';
import DoughAssistantApp from './components/DoughAssistantApp.vue';
import vue3GoogleLogin from 'vue3-google-login'
import { clientSecrets } from './ClientSecrets';

allIcons.forEach(icon => {
    addIcons(icon);
});

const app = createApp(DoughAssistantApp)

app.component("v-icon", OhVueIcon);

app.use(vue3GoogleLogin, {
    clientId: clientSecrets.googleClientId
  })
  
app.use(createPinia())
app.mount('#app')

