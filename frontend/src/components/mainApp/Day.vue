<template>
    <div class="day">
        <div :class="isToday ? 'day-date-label-today' : 'day-date-label'">
            {{ $props.day.getModel().getDate() }}
        </div>
    </div>
</template>

<script setup lang="ts">
import { DateTime } from '../../models/common/DateTime';
import { PropType } from 'vue';
import { computed } from '@vue/reactivity';

const props = defineProps({
    day: {
        type: Object as PropType<DateTime>,
        required: true
    },
})

const isToday = computed(() => {
    return DateTime.fromNow().sameDayAs(props.day);
});

</script>

<style scoped>
.day {
    border: 1px solid black;
    overflow-wrap: anywhere;
    padding: 5px;
    flex: 1
}

.day-date-label,
.day-date-label-today {
    color: white;
    max-width: 1rem;
    padding: 2px;
    font-size: small;
    text-align: center;
    border-radius: 5px;
}

.day-date-label {
    background-color: rgb(130, 130, 130);
}

.day-date-label-today {
    background-color: rgb(255, 0, 0);
}
</style>