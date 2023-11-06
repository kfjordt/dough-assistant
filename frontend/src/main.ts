import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import Week from './components/Week.vue';

const app = createApp(App)
app.use(createPinia())

app.component("Week", Week)

app.mount('#app')
