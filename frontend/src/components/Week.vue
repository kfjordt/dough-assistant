<script setup lang="ts">
import { DateTime } from '../models/DateTime';

const props = defineProps({
    days: Array<DateTime>
})

</script>

<template>
    <div class="week">
        <Day v-for="(day, idx) in days" :day="(day)" :key="(idx)" />
    </div>
</template>

<style scoped>
.week {
    display: flex;
    justify-content: space-between;
}
</style>