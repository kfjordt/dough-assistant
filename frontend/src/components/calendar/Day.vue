<template>
    <div class="day">
        <div :style="{ backgroundColor: addNewExpenseBgColor }" class="day-operations" @mouseout="setHovered(false)"
            @mouseover="setHovered(true)" @mousedown="setPressed(true)" @mouseup="setPressed(false)">
            <div class="day-operations-header">
                <div :style="{
                    backgroundColor: dateLabelStyle.background,
                    color: dateLabelStyle.text
                }" class="date-label-container">
                    {{ date }}
                </div>
            </div>
            <div class="expense-card-container">
                <ExpenseCard v-for="(expense, idx) in eligibleExpenses" :amount="expense.amount" :name="expense.name"
                    :key="idx" />
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { DateTime } from '../../models/common/DateTime';
import { PropType, ref } from 'vue';
import { computed } from '@vue/reactivity';
import { ApiService } from '../../api/ApiService';
import { useExpensesStore } from '../../stores/expenses';
import { useStyleStore } from '../../stores/style';
import ExpenseCard from './ExpenseCard.vue';
import { useCalendarStore } from '../../stores/calendar';

const props = defineProps({
    day: {
        type: Object as PropType<DateTime>,
        required: true
    },
})

const selectedMonth = useCalendarStore().selectedDate.getMonth()
const isPartOfCurrentMonth = computed(() => {
    return true
})

const style = computed(() => isPartOfCurrentMonth.value
    ? useStyleStore().sectionStyles.calendar
    : useStyleStore().sectionStyles.calendarDarkened)

const date = computed(() => props.day.getModel().getDate())
const dateLabelStyle = computed(() => {
    return DateTime.fromNow().sameDayAs(props.day)
        ? style.value.todayDateLabel
        : style.value.dateLabels
})

const isHovered = ref(false);
const isPressed = ref(false);

const addNewExpenseBgColor = computed(() => {
    return isPressed.value
        ? style.value.addNewExpenseButton.press
        : isHovered.value
            ? style.value.addNewExpenseButton.hover
            : style.value.addNewExpenseButton.background
})

const setPressed = (pressed: boolean) => {
    isPressed.value = pressed;
};

const setHovered = (hovered: boolean) => {
    isHovered.value = hovered;
};

const expensesStore = useExpensesStore()
const availableExpenses = computed(() => expensesStore.expenses)

const eligibleExpenses = computed(() => {
    return availableExpenses.value
        .filter(expense => DateTime.fromUnix(expense.time).sameDayAs(props.day))
})

const handleAddExpense = () => {
    // ApiService.postNewExpense({
    //     name: expenseName.value,
    //     amount: expenseAmount.value,
    //     time: props.day.getModel()
    // }).catch(error => console.error(error))

    // expensesStore.refreshAsync()
}

</script>

<style scoped>
.day {
    background-color: black;
    display: flex;
    padding: 4px;
}

.day-operations {
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    border-radius: 4px;
    cursor: pointer;
}

.day-operations-header {
    display: flex;
    flex-direction: row;
    margin: 4px;
    justify-content: space-between;
}

.expense-card-container {
    flex-grow: 1;
    height: 1px;
    align-items: center;

    display: flex;
    padding: 4px;
    flex-direction: column-reverse;
}

.date-label-container {
    aspect-ratio: 1 / 1;
    border-radius: 4px;
    padding: 4px;
    height: 0.8rem;
    font-size: 0.8rem;
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>