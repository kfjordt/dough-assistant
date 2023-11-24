import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { OhVueIcon, addIcons } from "oh-vue-icons"
import { allIcons } from './models/icons/Icons';
import vue3GoogleLogin from 'vue3-google-login'
import { clientSecrets } from './ClientSecrets';
import DoughAssistantApp from './components/DoughAssistantApp.vue';
import MainView from './components/other/MainView.vue';
import LoginScreen from './components/other/LoginScreen.vue';
import { createRouter, createWebHistory } from 'vue-router';
import EasterEgg from "./components/other/EasterEgg.vue"

allIcons.forEach(icon => {
    addIcons(icon);
});

const app = createApp(DoughAssistantApp)

app.component("v-icon", OhVueIcon);

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/main', component: MainView, name: "main" },
        { path: '/login', component: LoginScreen, name: "login" },
        { path: '/brainstorming', component: EasterEgg, name: "brainstorming" }
    ]
})

app.use(router)
app.use(vue3GoogleLogin, { clientId: clientSecrets.googleClientId })
app.use(createPinia())

app.mount('#app')

