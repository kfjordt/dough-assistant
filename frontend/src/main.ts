import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import Week from './components/Week.vue';
import Day from './components/Day.vue';

const app = createApp(App)
app.use(createPinia())

app.component("Week", Week)
app.component("Day", Day)

app.mount('#app')
