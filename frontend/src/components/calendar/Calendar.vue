<template>
    <div v-if="expensesRefreshed" :style="{
        backgroundColor: calendarStyle.main.border,
    }" class="calendar">
        <Day :style="{
            backgroundColor: calendarStyle.main.background,
        }" v-for="(day, index) in daysInCurrentMonth" :day="day" :key="index" />
    </div>
</template>

<script setup lang="ts">
import Day from './Day.vue';
import { computed } from '@vue/reactivity'
import { useCalendarStore } from '../../stores/calendar';
import { useExpensesStore } from '../../stores/expenses';
import { ref, onMounted } from 'vue';
import { useStyleStore } from '../../stores/style';

const expensesRefreshed = ref(false);
const expensesStore = useExpensesStore()

const calendarStyle = computed(() => useStyleStore().sectionStyles.calendar)

onMounted(async () => {
    await expensesStore.refreshAsync()
        .then(_ => expensesRefreshed.value = true)
        .catch(error => console.error(error));
});

const calendarStore = useCalendarStore()


const daysInCurrentMonth = computed(() => {
    return calendarStore.daysInCurrentMonth
})
</script>

<style scoped>
.calendar {
    flex-grow: 1;
    display: grid;
    grid-template-columns: repeat(7, 1fr);
    grid-auto-rows: 1fr;
    grid-auto-columns: 100px;
    gap: 1px;
    width: 100%;
}
</style>