import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'

import { OhVueIcon, addIcons } from "oh-vue-icons"
import { allIcons } from './models/icons/Icons';

allIcons.forEach(icon => {
    addIcons(icon);
});

const app = createApp(App)

app.component("v-icon", OhVueIcon);

app.use(createPinia())
app.mount('#app')
