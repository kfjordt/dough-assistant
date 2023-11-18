import { createApp } from 'vue'
import { createPinia } from 'pinia'

import { OhVueIcon, addIcons } from "oh-vue-icons"
import { allIcons } from './models/icons/Icons';
import DoughAssistantApp from './components/DoughAssistantApp.vue';

allIcons.forEach(icon => {
    addIcons(icon);
});

const app = createApp(DoughAssistantApp)

app.component("v-icon", OhVueIcon);

app.use(createPinia())
app.mount('#app')

