<template>
    <div class="week">
        <Day v-for="(day, idx) in props.week" :day="day" :key="idx" />
    </div>
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { DateTime } from '../../models/common/DateTime';
import Day from './Day.vue';

const props = defineProps({
    week: {
        type: Array as PropType<DateTime[]>,
        required: true
    },
});
</script>

<style scoped>
.week {
    display: flex;
    justify-content: space-between;
    align-items: stretch;
    display: flex;
    flex: 1;
}
</style>