<script setup lang="ts">
import type { PropType } from 'vue';
import { DateTime } from '../models/DateTime';
import { Guid } from 'guid-ts';
import { ApiService } from '../api/ApiService';

const props = defineProps({
    day: {
        type: Object as PropType<DateTime>,
        required: true
    }
})

let textBoxContent = ""
const handleButtonClick = () => {
    ApiService.sendPostRequest(textBoxContent)
        .then(reponse => {
            console.log("request finished with reponse code " + reponse.status)
        })
        .catch(response => {
            console.log("request failed")
        })
}
</script>

<template>
    <div>
        {{ day.getModel().toDateString() }}

        <input :id="Guid.newGuid().toString()" v-model="textBoxContent" type="text"/>
        <button @click="$event => handleButtonClick()">send</button>
    </div>
</template>

<style scoped></style>